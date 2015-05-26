// Write a boolean expression for finding if the bit 3
// (counting from 0) of a given integer is 1 or 0.

var isOne = 8, isZero = 1;

console.log(getBitAt(isOne, 3));
console.log(getBitAt(isZero, 3));

function getBitAt(number, position){
    return (number >> position) & 1;
}