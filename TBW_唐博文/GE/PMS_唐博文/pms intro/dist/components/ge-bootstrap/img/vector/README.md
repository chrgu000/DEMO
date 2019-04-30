IIDS SVG README
===============

We have extracted all the icons from Font Awesome as individual SVG files and offered the GE Monogram as SVG. The icons and GE Monogram have been created in  5 different colors (black, white, gray, light gray, and blue).


When to Use SVG
---------------
When you need resolution-independent imagery at pixel-perfect sizing, using SVG imagery is far more advantagous than using icon fonts. There are different ways to render SVGs on the web.

How to Use SVG
---------------

There are three main ways to add SVG on the web. Using CSS for SVG rendering provides the most flexibility and is the advised approach for displaying SVG. You can read more on the subject [**here**](http://coding.smashingmagazine.com/2012/01/16/resolution-independence-with-svg/).

###Code Examples

####SVG in CSS Backgrounds

`#myelement
{
	background-image: url(image.svg);
}`

####SVG as img Element

`<img src="image.svg" />`

####Inline SVG in HTML

`<div class="svg-img">
	<svg width="300px" height="300px" xmlns="http://www.w3.org/2000/svg">
		<text x="10" y="50" font-size="30">My SVG</text>
	</svg>
</div>`


Browser Support
---------------

In short, all modern browsers and IE9+ support SVG imagery. The breakdown below shows the breakdown of support across the different ways of displaying SVGs on the web.

- [**SVG in CSS Backgrounds**](http://caniuse.com/#feat=svg-css)
- [**SVG as img Element**](http://caniuse.com/#feat=svg-img)
- [**Inline SVG in HTML**](http://caniuse.com/#feat=svg-html5) 

Fallback Options
----------------
SVG will not work in IE8, so you will need to provide PNG fallbacks. We advise that you provide the fallback rules within the ie.less file found in preview/public/less/themes/iids/.


© General Electric