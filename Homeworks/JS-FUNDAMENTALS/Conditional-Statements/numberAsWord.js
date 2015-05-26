// 8. Write a script that converts a number in the range
// [0...999] to a text corresponding to its English
// pronunciation. Examples:
// 0 ? 'Zero'
// 273 ? 'Two hundred seventy three'
// 400 ? 'Four hundred'
// 501 ? 'Five hundred and one'
// 711 ? 'Seven hundred and eleven'

String.prototype.capitalize = function() {
    return this.charAt(0).toUpperCase() + this.slice(1);
};

var numbers = [0, 9, 10, 12, 19, 25, 98, 98, 273, 400, 501, 617, 711, 999];

for(var ind = 0; ind < numbers.length; ind++){
    console.log(numbers[ind] + '\t' + getString(numbers[ind]));
}

function getString(number){
    var text = '', 
		hundreds = Math.floor(number / 100) % 10,
		tens = Math.floor(number / 10) % 10,
		ones = number % 10;

    if(!hundreds && !tens && !ones){
        text = 'zero';
    }

    if (hundreds) {
        text += getDigit(hundreds) + ' hundred';
    }

    if (tens || ones) {
        if (text.length) {
            text += ' and ';
        }

        if (tens) {
            if (tens === 1) {
                return (text + getTeens(tens * 10 + ones)).capitalize();
            }
            text += getTens(tens);
        }

        if (ones) {
			if(tens){
				text += ' ';
			}
			
            text += getDigit(ones);
        }
    }

    return text.capitalize();
}

function getDigit (digit) {
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
        default: return '';
    }
};

function getTens (digit) {
    switch(digit){
        case 2: return 'twenty';
        case 3: return 'thirty';
        case 4: return 'forty';
        case 5: return 'fifty';
        case 6: return 'sixty';
        case 7: return 'seventy';
        case 8: return 'eighty';
        case 9: return 'ninety';
        default: return '';
    }
};

function getTeens (digit) {
    switch(digit){
        case 10: return 'ten';
        case 11: return 'eleven';
        case 12: return 'twelve';
        case 13: return 'thirteen';
        case 14: return 'fourteen';
        case 15: return 'fifteen';
        case 16: return 'sixteen';
        case 17: return 'seventeen';
        case 18: return 'eighteen';
        case 19: return 'nineteen';
        default: return '';
    }
};