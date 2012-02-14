/* Author: 

*/

(function ($, undefined) {
  if (!Modernizr.csstransitions) {
    // Provide fallback for browsers that don't support transitions
    $.getScript("js/csstransitions.js");
  }
  $(function () {
    var headers = $("body.sub section article div.content :header");

    if (headers.length) {
      (function () {
        var widget = $("<div />", { className: "widget widget-guide-contents" }),
            ul = $("<ul />"),
            prev_h1 = null,
            ul_holder;
        
        $("<h4 />", { text: "Guide Contents" }).appendTo(widget);
        
        headers.each(function (i, el) {
          var $el = $(el),
              $li = $("<li />", { 
                      html: $("<a />", { 
                        href: "#" + el.id, 
                        html: $el.html() 
                      }) 
                    });
          
          if ($el.is('h1')) {
            
            if (ul_holder && prev_h1) {
              prev_h1.append(ul_holder);
              ul_holder = null;
            }
            prev_h1 = $li;
            ul.append($li);
            
          } else {
            if (!ul_holder) {
              ul_holder = $("<ul />");
            }
            ul_holder.append($li);
          }
        });
        
        ul.appendTo(widget);
        widget.appendTo('section.body > aside');
      }());
    }
  })
}(jQuery));