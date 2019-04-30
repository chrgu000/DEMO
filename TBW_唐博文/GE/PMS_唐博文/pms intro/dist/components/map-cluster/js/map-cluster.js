require.config({
  paths: {
    'map-cluster-engine' : 'components/map-cluster/js/map-cluster-engine',
  }
});

'use strict';
define([
  'jquery',
  'OpenLayers',
  'd3-amd',
  'map-markers',
  'map-cluster-engine',
  'map-marker-types',
  'ge-bootstrap'],

function Cluster($, OpenLayers, d3, mapMarkers, mapClusterEngine, mapMarkerTypes) {

  var deferred = $.Deferred();

  var addClusters = function(collection,map){
    mapMarkerTypes.loadSVGMarkerElements();

    mapMarkerTypes.done(function(){

      var overlay = new OpenLayers.Layer.Vector("clusters");

      // Add the container when the overlay is added to the map.
      overlay.afterAdd = function () {

        var div = d3.selectAll("[id='" + overlay.div.id + "']");
        div.selectAll("svg").remove();
        var svg = div.append("svg");

        //Define marker types and icons
        ///////////////////////////////
        var clusterTypes = (function(){
          var clusterSizeScale,
              clusterDefinition = {
                  path: "m20.499,7.75c-6.708,0-12.144,5.438-12.144,12.146s5.436,12.146,12.144,12.146c6.707,0,12.146-5.438,12.146-12.146S27.205,7.75,20.499,7.75",
                  translation: -20.499,
                  strokeWidth: 11,
                  strokeMiterlimit: 10,
                  stroke: '#000'
              };
          var setClusterSizeScale = function(clusters){
            clusterSizeScale = d3.scale.linear()
              .domain([1 , d3.max(clusters, function(ele){return ele.attributes.count;})])
              .range([1, 2]);
          };

          var getClusterLabel = function(d){
            if (d.attributes.count === 1){
              // return 1+'';
              return d.metadata.icon;
            }
            else{
              return d.attributes.count+'';
            }
          };

          var getTranslation = function(d){
              var type = d.metadata.type;
              var size = d.metadata.size;

              var translationVal;

              translationVal = clusterDefinition.translation;

              translationVal *= getScale(d);
              return "translate(" + translationVal + ","  + translationVal + ")" + " scale(" + getScale(d) + ")";
          };

          var getScale = function(d){
            return clusterSizeScale(d.attributes.count);
          };

          return ({
              clusterDefinition : clusterDefinition,
              getTranslation: getTranslation,
              getClusterLabel: getClusterLabel,
              getScale: getScale,
              setClusterSizeScale: setClusterSizeScale
          });

        })();

        ////////////////////////////////////
        //Create markers
        ////////////////////////////////////

        var g = svg.append("g");

        var path = d3.geo.path().projection(project);

        var getFeaturePointTranslation = function(d){
              var pathString = path(d.geometry);
              var floatString = pathString.slice(1,pathString.indexOf("m"));
              var translateString = "translate(" + floatString + ")";
              return translateString;
        };

        var getMarkerAndFeatureStateClass = function(d){
            var markerState = (d.metadata.state ? d.metadata.state : '');
            var cssClass = markerState + ' marker';
            if (d.attributes.count > 1){
              cssClass += ' cluster';
            }
            return cssClass
        };

        map.events.register("moveend", map, reset);

        reset();

        //Update positions on map move

        function project(x) {
            var point = map.getViewPortPxFromLonLat(new OpenLayers.LonLat(x[0], x[1])
                .transform("EPSG:4326", "EPSG:900913"));
            return [point.x, point.y];
        };

        function render(clusters) {
          bounds = path.bounds(collection);

          g.selectAll("g")
            .remove();

          clusterTypes.setClusterSizeScale(clusters);

          //Create geo located group to contain the marker
          var feature = g.selectAll("g")
            .data(clusters)
            .enter().append("g")
            .attr("id",function(d,i){return d.id;})
            .attr("class",getMarkerAndFeatureStateClass)
            .on("mouseover", function(){
                d3.select(this)
                    .classed("active",true);
            })
            .on("mouseout", function(){
                d3.select(this)
                    .classed("active",false);
            })
            .on("dblclick", function(){
              d3.event.stopPropagation();
            });

          feature.each(function(d,i){
            if(d.attributes.count === 1){
              var thisMarker = this.appendChild( mapMarkerTypes.getSVGElement(d).cloneNode(true) );
              var data = d;
              d3.select(thisMarker)
              .attr("x", mapMarkerTypes.getTranslateX(data))
              .attr("y", mapMarkerTypes.getTranslateY(data))
            }
            else{
              // large outer dark radius
              d3.select(this).append("path")
                .attr('d',clusterTypes.clusterDefinition.path)
                .attr('transform',clusterTypes.getTranslation)
                .attr('stroke-width',clusterTypes.clusterDefinition.strokeWidth)
                .attr('stroke-miterlimit',clusterTypes.clusterDefinition.strokeMiterlimit)
                .attr('stroke',clusterTypes.clusterDefinition.stroke)
                .attr('stroke-opacity', '0.50');

              // main circle with tight dark border
              d3.select(this).append("path")
                .attr('d',clusterTypes.clusterDefinition.path)
                .attr('transform',clusterTypes.getTranslation);
            }
          });

          //Draw icon or cluster label
          feature.append('text')
            .attr('transform', function(d){return 'scale(' + clusterTypes.getScale(d) + ')'})
            .attr('text-anchor', 'middle')
            .attr('dominant-baseline', 'central')
            .attr('x', getIconXOffset)
            .attr('y', getIconYOffset)
            .attr('fill','white')
            .text(clusterTypes.getClusterLabel);

          var topLeft = bounds[0],
              bottomRight = bounds[1];

          //Compensate for size of cluster
          var clusterHeight = [];
          $("g .marker").each( function(){ clusterHeight.push( this.getBoundingClientRect().height)});
          var maxHeight = Math.max.apply(Math, clusterHeight);

          topLeft[0] = topLeft[0] - maxHeight;
          topLeft[1] = topLeft[1] - maxHeight;
          bottomRight[0] = bottomRight[0] + maxHeight;
          bottomRight[1] = bottomRight[1] + maxHeight;

          svg.attr("width", bottomRight[0] - topLeft[0] )
              .attr("height", bottomRight[1] - topLeft[1])
              .style("margin-left", topLeft[0] + "px")
              .style("margin-top", topLeft[1] + "px");

          g.attr("transform", "translate(" + -topLeft[0] + "," + -topLeft[1] + ")");

          feature.attr("transform", getFeaturePointTranslation);
        };

        function getIconXOffset(d){
          if (d.attributes.count === 1 && (d.metadata && d.metadata.iconPos)){
            return d.metadata.iconPos.x;
          }
        };

        function getIconYOffset(d){
          if (d.attributes.count === 1 && (d.metadata && d.metadata.iconPos)){
            return d.metadata.iconPos.y;
          }
        };       

        function reset(){
          render(mapClusterEngine.calculateClusters(overlay, collection));
        };
        deferred.resolve();
      };

      map.addLayer(overlay);
      $.publish('layerAdded', [map]);
    });
  };

  return deferred.promise({addClusters: addClusters });
});
