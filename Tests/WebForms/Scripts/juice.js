(function ( $ ) {
	'use strict';
	var stateFieldId = '_juiceWidgetOptions',

  Juice = {
		widgets: {},
    subscribe: window.amplify.subscribe,
    publish: window.amplify.publish,
    onSubmit: function () {
      var optionsInput = $( '#' + stateFieldId ),
				options = [];

      $.each( Juice.widgets, function ( index, widget ) {
        var element = $( '#' + widget.id ),
          widgetName = widget.widgetName, //element.data( 'ui-widget' ),
          uiWidget = element.data( widgetName );
				
				if( !uiWidget ){
					return;
				}

				var opts = $.extend( {}, uiWidget.options );

				$.each( opts, function( label ){
					if( $.inArray( label, widget.encodedOptions ) >= 0 ){
						opts[ label ] = htmlEncode( this );
					}
				});

        options.push({ id: widget.id, widgetName: widgetName, options: opts });
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

    $.each( Juice.widgets, function ( index, widget ) {
      var element = $( '#' + widget.id ),
        widgetName = widget.widgetName,
        events = {};

			if( !widgetName || !$.fn[widgetName] ) {
				return;
			}

			// map the event names to objects, merge with postBacks
			widget.events = $.map( widget.events, function( name ){
				return { name: name };
			});

			widget.postBacks = $.map( widget.postBacks, function( pb ){
				pb.causesPostBack = true;
				return pb;
			});

			widget.events = widget.events.concat( widget.postBacks );

      $.each( widget.events, function () {
        var event = this;
        events[event.name] = function ( jqEvent, ui ) {
        	var args = [].slice.call( arguments, 0 ),
            topic = widget.id + '.' + widgetName + '.' + event.name,
            uiWidget = element.data( widgetName );

        	args.splice( 0, 0, topic );
        	args.push( uiWidget );

        	// this publishes an amplify event with the arguments that correspond to the jquery ui event handler function parameters.
					Juice.publish.apply( this, args );

        	// Submit a postback if handler emitted - wee server side events!
        	if ( event.causesPostBack ) {
        		window.__doPostBack(widget.uniqueId, event.dataChangedEvent ? '' : event.name);
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
						
						window.console && console.log && console.log( 'Juice UI Error > elementId: ' + widget.id + '. widget: "' + widgetName + '". Bad data in "' + prop + '" option.' );
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
        delete Juice.widgets[widget.id];
      };
    });
  },

  endRequest = function ( sender, args ) {
    ready();
    registerCss();
  },

	htmlEncode = function( value ){
		return $( '<div/>' ).text( value ).html();
	};

	// The datepicker widget is "unique" in jQuery UI. It's internals aren't standardized like the other widgets.
	// Hence, it does not store an options hash natively. This extension provides that hash.
	// Credit - Scott Gonzales
	var _attachDatepicker = $.datepicker._attachDatepicker,
		_optionDatepicker = $.datepicker._optionDatepicker;

	$.datepicker._attachDatepicker = function( target ) {
		var inst;
		_attachDatepicker.apply( this, arguments );
		inst = this._getInst( target );
		inst.options = {};
		this._refreshOptions( target );
	};
	
	$.datepicker._refreshOptions = function( target ) {
		var inst = this._getInst( target );
		$.each(this._defaults, function( prop ) {
			inst.options[ prop ] = $.datepicker._get( inst, prop );
		});
	};
	
	$.datepicker._optionDatepicker = function( target ) {
		_optionDatepicker.apply( this, arguments );
		this._refreshOptions( target );
	};

	// The tabs widget triggers 'show' on create. Scott has stated that this behavior is unusual and won't be a part of 1.9.
	// Implementing a temporary workaround so that the tabs don't trigger a postback (if bound in codebehind) on page load.
	$.ui.tabs.prototype._created = false;

	var _tabify = $.ui.tabs.prototype._tabify,
		_trigger = $.ui.tabs.prototype._trigger;

	$.ui.tabs.prototype._tabify = function(){
		_tabify.apply( this, arguments );
		this._created = true;
	};

	$.ui.tabs.prototype._trigger = function( type ){
		if( type === "show" && !this._created ){
			return false;
		}
		return _trigger.apply( this, arguments );
	};

	// We need to proxy the ui.dialog._create method to assert that dialogs are appended to the end of the server form. 
	// Otherwise, any server controls within them will not retain their value during postback.

	var _create = $.ui.dialog.prototype._create;

	$.ui.dialog.prototype._create = function(  ){
		var result = _create.apply( this, arguments );
		var form = window.theForm || $('form:first');

		this.uiDialog.appendTo(form);

		return result;
	};
	

	// The autocomplete widget accepts a string and string array. This is problematic as we can't represent both 

	$( ready );
	Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest ); // handles adding the jquery ui css on partial postback, if it hasn't been already.
	window.Juice = Juice;

} )( jQuery );