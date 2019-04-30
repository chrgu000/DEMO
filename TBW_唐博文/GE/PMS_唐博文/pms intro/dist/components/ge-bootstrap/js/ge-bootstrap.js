require.config({
  shim: {
    'components/bootstrap/js/bootstrap-transition': ['jquery'],
    'components/bootstrap/js/bootstrap-affix': ['jquery'],
    'components/bootstrap/js/bootstrap-alert': ['jquery'],
    'components/bootstrap/js/bootstrap-button': ['jquery'],
    'components/bootstrap/js/bootstrap-carousel': ['jquery', 'components/bootstrap/js/bootstrap-transition'],
    'components/bootstrap/js/bootstrap-collapse': ['jquery', 'components/bootstrap/js/bootstrap-transition'],
    'components/bootstrap/js/bootstrap-dropdown': ['jquery'],
    'components/bootstrap/js/bootstrap-modal': ['jquery', 'components/bootstrap/js/bootstrap-transition'],
    'components/bootstrap/js/bootstrap-popover': ['jquery', 'components/bootstrap/js/bootstrap-tooltip'],
    'components/bootstrap/js/bootstrap-scrollspy': ['jquery'],
    'components/bootstrap/js/bootstrap-tab': ['jquery'],
    'components/bootstrap/js/bootstrap-tooltip': ['jquery'],
    'components/bootstrap/js/bootstrap-typeahead': ['jquery'],
    'ge-bootstrap/accordion': ['jquery']
  }
});

define([
    'jquery',
    'components/bootstrap/js/bootstrap-affix',
    'components/bootstrap/js/bootstrap-alert',
    'components/bootstrap/js/bootstrap-button',
    'components/bootstrap/js/bootstrap-modal',
    'components/bootstrap/js/bootstrap-scrollspy',
    'components/bootstrap/js/bootstrap-tab',
    'components/bootstrap/js/bootstrap-tooltip',
    'components/bootstrap/js/bootstrap-transition',
    'components/bootstrap/js/bootstrap-typeahead',
    'components/bootstrap/js/bootstrap-carousel',
    'components/bootstrap/js/bootstrap-collapse',
    'components/bootstrap/js/bootstrap-dropdown',
    'components/bootstrap/js/bootstrap-popover',
    'ge-bootstrap/accordion'
  ], function($) {
    'use strict';
    return $;
  }
);
