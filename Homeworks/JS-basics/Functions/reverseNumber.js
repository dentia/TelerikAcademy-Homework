// Write a function that reverses the digits of given
// decimal number. Example: 256 ? 652

console.log(reverseNumber(256));
console.log(reverseNumber(0));
console.log(reverseNumber(12345));

function reverseNumber(number){
    var result = 0;

    while(number){
        result = result * 10 + number % 10;
        number = Math.floor(number / 10);
    }

    return result;
}