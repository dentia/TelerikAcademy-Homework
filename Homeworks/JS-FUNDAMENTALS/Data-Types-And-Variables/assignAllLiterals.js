// Assign all the possible JavaScript literals to different variables.
// &&
// Try typeof on all variables you created.
// &&
// Create null, undefined variables and try typeof on them.

var string = 'string';
var int = 254;
var float = 25.4;
var arr = [1, 2, 3];
var object = {course: 'JS', part: 1};
var func = function(){return;};
var nullValue = null;
var undefinedValue = undefined;
var boolean = true;

var variables = [string, int, float, arr, object, func, nullValue, undefinedValue, boolean];

for(var variable in variables){
    console.log(getTypeString(variables[variable]));
}

function getTypeString(obj){
    var result = obj;
    result += ' is ' + typeof obj;
    return result;
}