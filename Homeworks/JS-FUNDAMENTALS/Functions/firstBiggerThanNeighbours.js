// 7. Write a function that returns the index of the first
// element in array that is bigger than its neighbors, or
// -1, if there’s no such element.
// ? Use the function from the previous exercise.

console.log(getIndexOfFirstBigger([5]));
console.log(getIndexOfFirstBigger([5,5]));
console.log(getIndexOfFirstBigger([]));
console.log(getIndexOfFirstBigger([1,1,3,1,5,1]));

function getIndexOfFirstBigger (arr) {
    for (var ind in arr) {
        if (isBigger(arr, ind)) {
			return ind;
		}
    }
	
    return -1;
}

function isBigger (arr, index) {
    var isBigger = true;

    for (var ind = index - 1; ind <= index + 1; ind += 2) {
        if (ind >= 0 && ind < arr.length) {
            if (arr[ind] >= arr[index]) {
                isBigger = false;
                break;
            }
        }
    }

    return isBigger;
}
