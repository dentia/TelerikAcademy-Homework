// Write an if statement that examines two integer
// variables and exchanges their values if the first one
// is greater than the second one.

var a = 10, b = 5;

printNumbers(a, b);

if(a > b){
    var tmp = a;
    a = b;
    b = tmp;
}

printNumbers(a, b);

function printNumbers(a, b){
    console.log(a + '\t' + b);
}