// Write a function that returns the last digit of given
// integer as an English word. Examples: 512 ? "two",
// 1024 ? "four", 12309 ? "nine"

console.log(getLastDigitAsWord(0));
console.log(getLastDigitAsWord(512));
console.log(getLastDigitAsWord(1024));
console.log(getLastDigitAsWord(12309));

function getLastDigitAsWord(number){
    switch (number % 10){
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
		default: return 'invalid number';
    }
}