// Write a script that finds the biggest of three integers
// using nested if statements.

var numbers = [-2, 7, 3];

console.log(getBiggest(numbers[0], numbers[1], numbers[2]));

function getBiggest(a, b, c){
    if(a > b){
        if(a > c){
            return a;
        }
        return c;
    }
	
    if(c > b){
        return c;
    }

    return b;
}