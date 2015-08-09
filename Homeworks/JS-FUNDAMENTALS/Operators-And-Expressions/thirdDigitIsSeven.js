// Write an expression that checks for given integer if
// its third digit (right-to-left) is 7. E. g. 1732 ? true.

var isSeven = 1732, notSeven = 1372;

console.log(thirdDigitIs7(isSeven));
console.log(thirdDigitIs7(notSeven));

function thirdDigitIs7(number){
    return (Math.floor(number / 100) % 10) === 7;
}
