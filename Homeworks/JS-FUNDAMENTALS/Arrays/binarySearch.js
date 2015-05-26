// Write a program that finds the index of given
// element in a sorted array of integers by using the
// binary search algorithm


var numbers = [3, 9, 10, 11, 14, 18, 23, 24, 28, 29, 37, 38, 41, 44, 47],
	numbersToFind = [2, 3, 10, 27, 29, 47, 55];
	
// the array must be sorted, otherwise the binary search won't work
numbers.map(Number).sort();
	
for (var ind = 0; ind < numbersToFind.length; ind++) {
	console.log(numbersToFind[ind] + '\t[' + 
		binarySearch(numbers, numbersToFind[ind], 0, numbers.length - 1) + ']');
}

function binarySearch(arr, num, min, max) {
	var mid = min + Math.floor((max - min) / 2);
	
    if (max < min || num > arr[max]) {
        return -1;
    }

    if (arr[mid] > num) {
        return binarySearch(arr, num, min, mid - 1);
    } else if (arr[mid] < num) {
        return binarySearch(arr, num, mid + 1, max);
    } else {
        return mid;
    }
}