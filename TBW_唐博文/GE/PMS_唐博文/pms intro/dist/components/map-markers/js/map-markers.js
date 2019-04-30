require.config({
  paths: {
    'map-marker-types' : 'components/map-markers/js/map-marker-types',
    'map-d3-overlay'      : 'components/map-markers/js/map-d3-overlay',
    'map-vector-data-layer' : 'components/map-markers/js/map-vector-data-layer',
    'pubsub' : 'components/map-core/js/pubsub'
  }
});

'use strict';
define([
  'jquery',
  'map-d3-overlay',
  'map-popovers',
  'ge-bootstrap',
  'pubsub'],

function Markers($, mapOverlay, popovers) {

  var addMarkers = function(collection,map,markerOptions,name,indexOptions){

    if(!name){
      name = 'Markers';
    }

    //Merge options with defaults
    $.extend(true,popovers.popupOptions,markerOptions);

    var mapDSoverlay = new mapOverlay(collection, map, name, true, indexOptions).done(function(){
      popovers.addPopovers(map, mapDSoverlay.overlay(), mapDSoverlay.feature(), collection);
      $.publish("markerLayerInitialised", [mapDSoverlay]);
    });
    return mapDSoverlay;

  };

  return( {addMarkers: addMarkers } );
});
