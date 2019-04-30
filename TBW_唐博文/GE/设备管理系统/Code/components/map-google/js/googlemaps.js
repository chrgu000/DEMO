require.config({
  paths: {
    'googlemaps-loader' : 'components/map-google/js/googlemaps-loader',
  }
})

// convert Google Maps into an AMD module
define(['googlemaps-loader!'],
function GoogleMaps() {
  // return the gmaps namespace
  return window.google;
});
