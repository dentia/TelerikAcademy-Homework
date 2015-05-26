// Write script that asks for a digit and depending on
// the input shows the name of that digit (in English)
// using a switch statement.

for(var digit = 0; digit <= 10; digit++){
    console.log(digit + '\t' + getDigitToWord(digit));
}
console.log('hi\t' + getDigitToWord('hi'));

function getDigitToWord(digit){
    switch(digit){
        case 0: return 'zero';
        case 1: return 'one';
        case 2: return 'two';
        case 3: return 'three';
        case 4: return 'four';
        case 5: return 'five';
        case 6: return 'six';
        case 7: return 'seven';
        case 8: return 'eight';
        case 9: return 'nine';
        default: return 'not a digit';
    }
}