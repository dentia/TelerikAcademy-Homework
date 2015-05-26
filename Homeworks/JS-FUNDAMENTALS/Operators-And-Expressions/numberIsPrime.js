// Write an expression that checks if given positive
// integer number n (n ? 100) is prime. E.g. 37 is prime.

var prime = 37, notPrime = 36;

console.log(isPrime(prime));
console.log(isPrime(notPrime));

function isPrime(number){
    if(number < 2) return false;

    for(var divisor = 2; divisor <= Math.sqrt(number); divisor++){
        if(!(number % divisor)) return false;
    }

    return true;
}
