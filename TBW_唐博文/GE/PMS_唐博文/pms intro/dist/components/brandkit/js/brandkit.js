'use strict';
!function(window, document, undefined) {

  var monochromePalette = {
    'black': '#13161a',
    'grayDarkest': '#313337',
    'grayDarker': '#3f4145',
    'grayDark': '#5c5f63',
    'gray': '#999c9f',
    'grayLight': '#bfc2c5',
    'grayLighter': '#e1e2e5',
    'grayLightest': '#edeeef',
    'offwhite': '#f7f8fa',
    'white': '#fff'
  };

  var accentPalette = {
    'cyan': '#08a5e1',
    'orange': '#ed8000',
    'green': '#76b900',
    'purple': '#711371',
    'red': '#ee3324',
    'cyanLight': '#6bc9ed',
    'orangeLight': '#f4b366',
    'greenLight': '#add566',
    'purpleLight': '#aa71aa',
    'redLight': '#f5857c',
    'cyanDark': '#056083',
    'orangeDark': '#ca4d00',
    'greenDark': '#446b00',
    'purpleDark': '#420b42',
    'redDark': '#8a1e15',
    'blue': '#3b73b9',
    'blueLight': '#89abd5',
    'blueDark': '#22436b'
  };

  var typography = {
    'sansFontFamily': '"Helvetica Neue", Helvetica, Arial, sans-serif',
    'serifFontFamily': 'Georgia, serif',
    'monoFontFamily': 'Inconsolata, Consolas, monospace',
    'brandFontFamily': '"ge-inspira", "Helvetica Neue", Helvetica, Arial, sans-serif',
    'baseFontSize': '14px',
    'baseLineHeight': '20px',
    'textColor': monochromePalette.grayDarker
  };

  var brandkit = {
    'accentPalette': accentPalette,
    'monochromePalette': monochromePalette,
    'typography': typography
  };

  if (typeof define === 'function' && define.amd)
    define(function() { return brandkit; });
  else
    window.brandKit = brandkit;

}(window, document);
