// Write a script that finds the greatest of given 5 variables.

var numbers = [72, 99, 59, 23, 66];

var greatest = numbers[0];

for(var ind = 1; ind < numbers.length; ind++){
    if(numbers[ind] > greatest){
        greatest = numbers[ind];
    }
}

console.log(greatest);