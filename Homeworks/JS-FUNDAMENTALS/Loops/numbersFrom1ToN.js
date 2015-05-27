// Write a script that prints all the numbers from 1 to N

var n1 = 5,
	n2 = -5;
	
	printToN(n1);
	printToN(n2);

function printToN(n) {
	var change = n < 1 ? -1 : 1,
		tmp = 1;
	
	while (true) {
		console.log(tmp);
		
		if (tmp === n) {
			break;
		}
		
		tmp += change;
	}
}