// Write a script that finds the greatest of given 5 variables.

console.log(getBiggest(5, 2, 2, 4, 1));
console.log(getBiggest(-2, -22, 1, 0, 0));
console.log(getBiggest(-2, 4, 3, 2, 0));
console.log(getBiggest(0, -2.5, 0, 5, 5));
console.log(getBiggest(-3, -0.5, -1.1, -2, -0.1));

function getBiggest(a, b, c, d, e){
	var biggest = Math.max();
	
	if(a > biggest){
		biggest = a;
	}
	if(b > biggest){
		biggest = b;
	}
	if(c > biggest){
		biggest = c;
	}
	if(d > biggest){
		biggest = d;
	}
	if(e > biggest){
		biggest = e;
	}
	
	return biggest;
}