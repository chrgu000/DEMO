require.config({
    baseUrl: './',
    paths: {
        iids: 'js/iids',
        brandkit: 'components/brandkit/js/brandkit',
        'cascading-list': 'components/cascading-list/js/cascading-list',
        charts: 'components/charts/js/charts',
        'collapsible-list': 'components/collapsible-list/js/collapsible-list',
        "col-reorder-amd": "components/datatables-col-reorder/index",
        "datatables-scroller": "components/datatables-scroller/index",
        contextmenu: 'components/contextmenu/js/contextmenu',
        'd3-amd': 'components/d3-amd/d3',
        datagrids: 'components/datagrids/js/datagrids',
        datatables: "components/datatables/dist/media/js/jquery.dataTables",
        datepicker: 'components/datepicker/js/datepicker',
        'declarative-visualizations': 'components/declarative-visualizations/js/declarative-visualizations',
        'ge-bootstrap': 'components/ge-bootstrap/js/ge-bootstrap',
        'iids-navbar': 'components/iids-navbar/js/iids-navbar',
        jquery: 'components/jquery/jquery.min',
        'jquery-csv': 'components/jquery-csv/src/jquery.csv',
        'jqueryui-sortable-amd': 'components/jqueryui-sortable-amd/js/jquery-ui-1.10.2.custom',
        'jQuery-contextMenu': 'components/jQuery-contextMenu/src/jquery.contextMenu',
        modernizr: 'components/modernizr/modernizr',
        jumpnav: 'components/jumpnav/js/jumpnav',
        modules: 'components/modules/js/modules',
        prettify: 'components/prettify/prettify',
        respond: 'components/respond/respond.src',
        'responsive-emitter': 'components/responsive-emitter/js/responsive-emitter',
        'responsive-tables': 'components/responsive-tables/js/responsive-tables',
        spinner: 'components/spinner/js/spinner',
        trays: 'components/trays/js/trays',
        spin: 'components/spin.js/dist/spin',
        highcharts: 'components/highcharts-amd/js/highcharts.src',
        highstock: 'components/highcharts-amd/js/highstock.src',
        'highcharts-more': 'components/highcharts-amd/js/highcharts-more.src',
        'bootstrap-datepicker': 'components/bootstrap-datepicker/js/bootstrap-datepicker',
        'jquery-ui-touch-punch': 'components/jquery-ui-touch-punch/jquery.ui.touch-punch',
        'multi-step-navigation': 'components/multi-step-navigation/js/multi-step-navigation',
        'twitter-bootstrap-wizard': 'components/twitter-bootstrap-wizard/jquery.bootstrap.wizard',
        requirejs: 'components/requirejs/require',
        videoplayer: 'components/videoplayer/js/videoplayer',
        videojs: 'components/videoplayer/js/video',
        'map-core': 'components/map-core/js/map-core',
        'map-cluster': 'components/map-cluster/js/map-cluster',
        'map-street-view': 'components/map-core/js/map-streetview',
        'map-layer-list': 'components/map-layerlist/js/map-layer-list',
        'map-geolocate': 'components/map-geolocate/js/map-geolocate',
        'map-google': 'components/map-google/js/googlemaps',
        'map-loader': 'components/map-core/js/map-loader',
        'map-markers': 'components/map-markers/js/map-markers',
        'map-popovers': 'components/map-popovers/js/map-popovers',
        'map-search': 'components/map-search/js/asset-address-search',
        'map-zoom': 'components/map-zoom/js/map-zoom',
        pubsub: 'components/map-core/js/pubsub',
        'hogan': 'components/hogan/index',
        'underscore': 'components/underscore-amd/index',
        OpenLayers: 'components/open-layers/dist/OpenLayers',
        'map-layerlist': 'components/map-layerlist/js/map-layer-list',
        navbar: 'components/navbar/js/iids-navbar',
        'highcharts.src': 'components/highcharts-amd/js/highcharts.src',
        'highstock.src': 'components/highcharts-amd/js/highstock.src',
        'highcharts-more.src': 'components/highcharts-amd/js/highcharts-more.src',
        'bootstrap-switch': 'components/bootstrap-switch/static/js/bootstrap-switch',
        'oo-utils': 'components/oo-utils/src/js/oo-utils',
        'toggle-switch': 'components/toggle-switch/src/js/toggle-switch',
        'moment': 'components/momentjs/min/moment.min',
        'bootstrap-timepicker': 'components/bootstrap-timepicker/index',
        'timepicker': 'components/timepicker/src/js/timepicker',
        'slider': 'components/slider/js/slider',
        'bootstrap': 'components/bootstrap/js'
    },
    shim: {
        OpenLayers: {
            exports: 'OpenLayers'
        },
        'jquery-csv': [
            'jquery'
        ],
        'bootstrap-switch': ['jquery'],
        'bootstrap-timepicker': ['jquery'],
        "col-reorder-amd": {
            deps: ['jquery', 'datatables']
        },
        'datagrids/datagrids-col-vis': {
            deps: ['jquery', 'datatables']
        }
    }
});
