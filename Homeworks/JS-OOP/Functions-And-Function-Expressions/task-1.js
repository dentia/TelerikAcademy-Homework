// Write a function that sums an array of numbers:
// Numbers must be always of type Number
// Returns null if the array is empty
// Throws Error if the parameter is not passed (undefined)
// Throws if any of the elements is not convertible to Number

function sum(numbers) {
    if(numbers === undefined) {
        throw new Error('The array cannot be undefined.');
    } else if(!numbers.length){
        return null;
    } else {
        if(!numbers.every(function(num) {
                return num == Number(num);
            })) {
            throw new Error('All elements must be numbers.');
        }

        return numbers.reduce(function(currentSum, number) {
            return currentSum + +number;
        }, 0);
    }
}