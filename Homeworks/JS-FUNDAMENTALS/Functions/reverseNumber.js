// Write a function that reverses the digits of given
// decimal number. Example: 256 ? 652

console.log(reverseNumber(256));
console.log(reverseNumber(123.45));
console.log(reverseNumber(-32.1));

function reverseNumber(number){
	var isNegative = number < 0,
		number = number.toString().replace('-', '').split(''),
		reversed = [];
		
		if (isNegative) {
			reversed.push('-');
		}
		
		Array.prototype.push.apply(reversed, number.reverse());
	
	return +(reversed.join(''));
}