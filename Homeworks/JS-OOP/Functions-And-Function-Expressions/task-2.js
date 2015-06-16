// Write a function that finds all the prime numbers in a range
// It should return the prime numbers in an array
// It must throw an Error if any of the range params is not convertible to Number
// It must throw an Error if any of the range params is missing

function getPrimesInRange(start, end) {
    if(arguments.length < 2) {
        throw  new Error('The function must have both starting and ending point.');
    } else if (!isNumber(start) || !isNumber(end)) {
        throw  new Error('Both the starting and ending parameter must be convertible to numbers.');
    } else {
        var primes = [],
            num;
        start = +start;
        end = +end;

        for(num = start; num <= end; num += 1) {
            if(isPrime(num)) {
                primes.push(num);
            }
        }

        return primes;
    }

    function isNumber(str) {
        return str == Number(str);
    }

    function isPrime(number) {
        var maxDivisor = Math.sqrt(number),
            isPrime = true,
            currDivisor;

        if(number < 2) {
            return false;
        }

        for(currDivisor = 2; currDivisor <= maxDivisor; currDivisor += 1) {
            if(!(number % currDivisor)) {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }
}