// Sorting an array means to arrange its elements in
// increasing order. Write a script to sort an array. Use
// the "selection sort" algorithm: Find the smallest
// element, move it at the first position, find the
// smallest from the rest, move it at the second
// position, etc.

function selectionSort(arr) {
	for (var left = 0; left < arr.length; left++) {
		for (var right = left + 1; right < arr.length; right++) {
			if (arr[left] > arr[right]) {
				var tmp = arr[right];
				arr[right] = arr[left];
				arr[left] = tmp;
			}
		}
	}
}

var numbers =  [8, 12, 3, 4, 5, 2, 11, 13, 7, 4, 15, 14, 12, 8, 1];
selectionSort(numbers);
console.log(numbers);
