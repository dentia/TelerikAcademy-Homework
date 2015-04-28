// Write a script that shows the sign (+ or -) of the
// product of three real numbers without calculating it.
// Use a sequence of if statements.

console.log([0, 5, -5] + ' -> ' + getSign([0, 5, -5]));
console.log([5, 5, -5] + ' -> ' + getSign([5, 5, -5]));
console.log([-5, 5, -5] + ' -> ' + getSign([-5, 5, -5]));
console.log([-5, -5, -5] + ' -> ' + getSign([-5, -5, -5]));
console.log([5, 5, 5] + ' -> ' + getSign([5, 5, 5]));

function getSign(numbers){
    var negativeCount = 0;

    for(var ind = 0; ind < numbers.length; ind++){
        if(numbers[ind]){
            if(numbers[ind] * -1 > numbers[ind]){
                ++negativeCount;
            }
        }else{
            return 0;
        }
    }

    return (negativeCount % 2) ? '-' : '+';
}

