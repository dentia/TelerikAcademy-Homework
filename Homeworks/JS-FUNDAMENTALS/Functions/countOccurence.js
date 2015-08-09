// Write a function that counts how many times given
// number appears in given array. Write a test function
// to check if the function is working correctly.

var arraysToCheck = {
	a: {
		array: [4, 4, 4, 2, 2, 2, 2, 4, 4, 4, 1, 2, 3, 4],
		number: 4,
		expected: 7
	},
	b: {
		array: [5],
		number: 2,
		expected: 0
	},
	c: {
		array: [1, 1, 1],
		number: 1,
		expected: 3
	}
}

for (var arr in arraysToCheck) {
	var curr = arraysToCheck[arr],
		result = curr.array + ' /number: ' + curr.number + 
			' /expected: ' + curr.expected + 
			' /result: ' + assert(curr.array, curr.number, curr.expected);
		
	console.log(result);
}

function getCount(arr, number){
    var count = 0;

    for (var ind = 0; ind < arr.length; ind++) {
		if (arr[ind] == number) {
			++count;
		}
	}

    return count;
}

function assert(arr, number, expected){
    return getCount(arr, number) === expected;
}