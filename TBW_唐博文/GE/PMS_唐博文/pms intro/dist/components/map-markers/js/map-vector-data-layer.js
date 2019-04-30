'use strict';
define([
  'jquery',
  'map-d3-overlay',
  'map-popovers',
  'ge-bootstrap'],

function VectorDataLayer($, mapOverlay, popovers) {

  var addGeoJSON = function(collection, map, markerOptions, name){

    if(!name){
      name = 'GeoJSON';
    }

    //Merge options with defaults
    $.extend(true, popovers.popupOptions, markerOptions);

    var mapDSoverlay = new mapOverlay(collection, map, name, false);

  };

  return( {addGeoJSON: addGeoJSON } );
});
