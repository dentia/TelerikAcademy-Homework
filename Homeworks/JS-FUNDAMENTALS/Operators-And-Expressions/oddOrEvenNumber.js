// Write an expression that checks if given integer is odd or even.

var even = 4, odd = 5;

console.log(isOdd(even));
console.log(isOdd(odd));

function isOdd(number){
    return Boolean(number & 1);
}
