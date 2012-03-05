(function ( $ ) {
	'use strict';
	var stateFieldId = '_juiceWidgetOptions',

  Juice = {
		widgets: {},
    subscribe: window.amplify.subscribe,
    publish: window.amplify.publish,
    onSubmit: function () {
      var optionsInput = $( '#' + stateFieldId ),
				options = {};

      $.each( Juice.widgets, function ( id, widgetData ) {
        var element = $( '#' + id ),
          widgetName = element.data( 'ui-widget' ),
          widget = element.data( widgetName );

        options[id] = widget.options;
      });

      optionsInput.val( JSON.stringify( options ) );
    }
  },

  registerCss = function () {
    if ( !$( '#_jQueryUICss' ).length ) {
      var href = Juice.cssUrl,
        tag = '<link rel="stylesheet" type="text/css" href="' + href + '" />';
      $( 'head' ).append( tag );
    }
  },

  ready = function () {
    if ( typeof ( window.JSON ) === 'undefined' ) {
      throw new Error( 'Juice requires JSON support. Please ensure json2.js is referenced for downlevel browsers.' );
    }

    if ( !$( '#' + stateFieldId ).length ) {
      $( '<input id="' + stateFieldId + '" name="' + stateFieldId + '" type="hidden" />' )
			  .appendTo( window.theForm ); // theForm is defined by asp.net
    }

    $.each( Juice.widgets, function ( id, widget ) {
      var element = $( '#' + id ),
        widgetName = element.attr( 'data-ui-widget' ),
        events = {};

      if ( !widgetName || !$.fn[widgetName] ) {
        return;
      }

      $.each( widget.events, function () {
        var event = this;
        events[event.name] = function ( jqEvent, ui ) {
        	var args = [].slice.call( arguments, 0 ),
            topic = id + '.' + widgetName + '.' + event.name,
            uiWidget = element.data( widgetName );

        	args.splice( 0, 0, topic );
        	args.push( uiWidget );

        	// this publishes an amplify event with the arguments that correspond to the jquery ui event handler function parameters.
        	Juice.publish.apply( this, args );

        	// Submit a postback if handler emitted
        	if ( event.handler ) {
        		// TODO: EVIL eval, maybe we can clean this up later
        		eval( event.handler );
        	}
        };
      });

			$.each( widget.options, function( prop ) {
				if( this.eval ){
					var on = this.on;

					try {
						widget.options[ prop ] = eval( '(' + this.on + ')' );
					}
					catch ( e ) { // if bad data/string is entered for the Eval property, an exception is thrown. Remove the bad data and prop.
						delete widget.options[ prop ];
						
						window.console && console.log && console.log( 'Juice UI Error > elementId: ' + id + '. widget: "' + widgetName + '". Bad data in "' + prop + '" option.' );
					}
				}
			});

      // merge events with options
      $.extend( widget.options, events );

      // Invoke the jQuery UI extension method on the element with the options only if it hasn't already been called
      if ( !element.data( widgetName ) ) {
        element[widgetName]( widget.options );
      }

      // Wire up dispose method which update panels will call when element is destroyed
      element[0].dispose = function () {
        delete Juice.widgets[id];
      };
    });
  },

  endRequest = function ( sender, args ) {
    ready();
    registerCss();
  };

	$( ready );
	Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest ); // handles adding the jquery ui css on partial postback, if it hasn't been already.
	window.Juice = Juice;
} )( jQuery );