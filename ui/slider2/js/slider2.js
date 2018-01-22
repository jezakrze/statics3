$(function(){

	
	$('#slider2')
	.anythingSlider({
		resizeContents      : false,
		navigationFormatter : function(i, panel){
			return ['Rotor Blade Repair','Whirl Tower', 'Field Service'][i - 1];
		}
	})
	.anythingSliderFx({
		// base FX definitions
		// '.selector' : [ 'effect(s)', 'distance/size', 'time', 'easing' ] - 'time' and 'easing' are optional parameters
		'.quoteSlide:first *' : [ 'grow', '24px', '400', 'easeInOutCirc' ],
		'.quoteSlide:last'    : [ 'top', '500px', '400', 'easeOutElastic' ],
		'.expand'             : [ 'expand', '10%', '400', 'easeOutBounce' ],
		'.textSlide h3'       : [ 'top left', '200px', '500', 'easeOutCirc' ],
		'.textSlide img,.fade': [ 'fade' ],
		'.textSlide li'       : [ 'listLR' ]
		/*
		// for more precise control, use the "in" and "out" definitions
		// in = the animation that occurs when you slide "in" to a panel
		,inFx  : {
			'.textSlide h3'  : { opacity: 1, top  : 0, duration: 400, easing : 'easeOutBounce' },
			'.textSlide li'  : { opacity: 1, left : 0, duration: 400 },
			'.textSlide img' : { opacity: 1, duration: 400 },
			'.quoteSlide'    : { top : 0, duration: 400, easing : 'easeOutElastic' },
			'.expand'        : { width: '100%', top: '0%', left: '0%', duration: 400, easing : 'easeOutBounce' }
		},
		// out = the animation that occurs when you slide "out" of a panel
		// (it also occurs before the "in" animation) - outFx animation time is 1/2 of inFx time
		outFx : {
			'.textSlide h3'      : { opacity: 0, top  : '-100px', duration: 200 },
			'.textSlide li:odd'  : { opacity: 0, left : '-200px', duration: 200 },
			'.textSlide li:even' : { opacity: 0, left : '200px',  duration: 200 },
			'.textSlide img'     : { opacity: 0, duration: 200 },
			'.quoteSlide:first'  : { top : '-500px', duration: 200 },
			'.quoteSlide:last'   : { top : '500px', duration: 200 },
			'.expand'            : { width: '10%', top: '50%', left: '50%', duration: 200 },
		}
		*/
	});


});