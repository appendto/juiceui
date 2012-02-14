exports.capitalize = function(str) {
	return str[0].toUpperCase() + str.substring(1);
}

exports.getCSharpType = function(option) {
	var typeMap = {
			'String' : 'string',
			'Selector' : 'string',
			'Number' : 'int',
			'Integer' : 'int',
			'Float' : 'float',
			'Boolean' : 'bool',
			'Array' : 'string[]',
			'Function' : 'string',
			'Options' : 'evalstring',
			'Function' : 'evalstring',
			'Object' : 'evalstring'
	};
	
	// If the type is an array of options, the appropriate server-side
	//  type is almost always a string.
	if (option.type.indexOf(',') !== -1)
		return 'string';
		
	if (option.type === 'Array') {
    if (detectArrayType(option) === 'int')
      return 'int[]';
    else
      return 'string[]';
	}

	if (typeMap[option.type])
		return typeMap[option.type];

	// else
	return 'unknown';
}

exports.getTypeConverter = function(option) {
	if (detectArrayType(option) === 'int')
		return 'Int32ArrayConverter';

	// else
	return 'StringArrayConverter';
}

exports.formatOptionDefault = function(option) {
	// If the default is a string, the WidgetOption[] attribute needs
	//  the default wrapped in double quotes, not single.
	if (option.type === 'String' || option.defaultValue[0] === "'")
		return option.defaultValue.replace(/'/g, '"');
		
	// If the default is an Array, wrap it in double quotes to make it a
	//  string. The TypeConverters will handle making proper use of the string.
	if (option.type === 'Array')
    return 'new ' + detectArrayType(option) + '[] ' + 
            option.defaultValue.replace('[', '{').replace(']', '}').replace(/'/g, '"');

	// For null-ish defaults of types such as function or options
	//  with more than one possible type, empty string should pass through.
	if (option.defaultValue == '')
		return '""';

	// else
	return option.defaultValue;
}

function detectArrayType(option) {
  if (option.defaultValue.indexOf("'") === -1)
    return 'int';
    
  // else
  return 'string';
}