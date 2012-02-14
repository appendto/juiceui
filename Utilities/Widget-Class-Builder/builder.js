var fs = require('fs'),
	request = require('request'),
	util = require('./utilities');

if (!process.argv[2]) {
	console.error('Please supply the jQuery UI widget name (e.g. datepicker) as the first argument to this script');
}

var widgetName = process.argv[2],
	fileName = process.argv[3] ? process.argv[3] : null,
	classTemplate = '\
using System;\n\
using System.Collections;\n\
using System.Collections.Generic;\n\
using System.ComponentModel;\n\
using System.Linq;\n\
using System.Text;\n\
using System.Web;\n\
using System.Web.UI;\n\
using System.Web.UI.WebControls;\n\n\
using Juice.Attributes;\n\n\
namespace Juice {\n\
\tpublic class ' + util.capitalize(widgetName) + ' : JuiceExtender {\n\n\
public ' + util.capitalize(widgetName) + '() : base("' + widgetName + '") { }\n\n\
\t\t#region Widget Options\n\n\
#options#\
\t\t#endregion\n\n\
\t\t#region Widget Events\n\n\
#events#\
\t\t#endregion\n\n\
\t}\n}';


request({ uri: 'http://jqueryuiapi.com/api/' + widgetName }, function(err, response, body) {
	var widget = JSON.parse(body),
		options = '',
		events = '';

	for (var i = 0; i < widget.options.length; i++) {
		var option = widget.options[i],
			cSharpType = util.getCSharpType(option),
			defaultValue = util.formatOptionDefault(option),
			eval = '';

		if(cSharpType == 'evalstring'){
			cSharpType = 'string';
			eval = ', Eval=true';
			defaultValue = '"{}"';
		}

		options += '\t\t/// <summary>';
		options += '\n\t\t/// ' + option.description;
		options += '\n\t\t/// Reference: http://jqueryui.com/demos/' + widget.name + '/#' + option.name;
		options += '\n\t\t/// </summary>';
		options += '\n\t\t[WidgetOption("' + option.name + '", ' + defaultValue + eval + ')]';

		if (option.type === 'Array'){
			options += '\n\t\t[TypeConverter(typeof(' + util.getTypeConverter(option) + '))]';
		}

		options += '\n\t\tpublic ' + cSharpType + ' ' + util.capitalize(option.name) + ' { get; set; }';
		options += '\n\n';
	}	
	
	for (var i = 0; i < widget.events.length; i++) {
		var event = widget.events[i];
		
		events += '\t\t/// <summary>';
		events += '\n\t\t/// ' + event.description.replace('\n', '\n\t\t/// ');
		events += '\n\t\t/// Reference: http://jqueryui.com/demos/' + widget.name + '/#' + event.name;
		events += '\n\t\t/// </summary>';
		events += '\n\t\t[WidgetEvent("' + event.name + '")]';
		events += '\n\t\tpublic event EventHandler ' + util.capitalize(event.name) + ';';
		events += '\n\n';
	}		
	
	var output = classTemplate
								.replace('#events#', events)
								.replace('#options#', options);
	
	if(fileName){
		fs.writeFile(fileName, output);
	}
	else{
		console.log(output);
	}

});
