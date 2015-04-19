// Write an expression that checks if given integer is odd or even.

var even = 4, odd = 5;

console.log(isEven(even));
console.log(isEven(odd));

function isEven(number){
    return !(number % 2);
}
