// Write a script that shows the sign (+ or -) of the
// product of three real numbers without calculating it.
// Use a sequence of if statements.

var numbers = [-5, 0, 5];

for(var ind in numbers){
    var number = numbers[ind];

    console.log(number + '\t' + getSign(number));
}

function getSign(number){
    if(number){
        if(number > 0){
            return '+';
        }
        return '-';
    }
    return '0';
}

