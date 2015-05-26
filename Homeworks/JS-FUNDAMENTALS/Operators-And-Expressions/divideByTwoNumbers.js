// Write a boolean expression that checks for given
// integer if it can be divided (without remainder) by 7
// and 5 in the same time.

var divisable = 35, notDivisable = 34;

console.log(isDivisable(divisable, 5, 7));
console.log(isDivisable(notDivisable, 5, 7));

function isDivisable(number, divisor1, divisor2){
    return !((number % divisor1) || (number % divisor2));
    // if we are sure the two divisors are coprime, we can return !(number % (divisor1 * divisor2))
}
