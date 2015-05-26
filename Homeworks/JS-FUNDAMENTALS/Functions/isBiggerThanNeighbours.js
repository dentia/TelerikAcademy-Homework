// Write a function that checks if the element at given
// position in given array of integers is bigger than its
// two neighbors (when such exist).

console.log(isBigger([1,3,1], 1));
console.log(isBigger([1], 0));
console.log(isBigger([1,3,1], 0));

function isBigger(arr, index){
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
