// Write a program that finds the index of given
// element in a sorted array of integers by using the
// binary search algorithm

var numbers = [3, 9, 10, 11, 14, 18, 23, 24, 28, 29, 37, 38, 41, 44, 47];

console.log(binarySearch(numbers, 10, 0, numbers.length));
console.log(binarySearch(numbers, 27, 0, numbers.length));
console.log(binarySearch(numbers, 29, 0, numbers.length));

function binarySearch(arr, num, min, max){
    if(max < min){
        return -1;
    }

    var mid = min + Math.floor((max - min) / 2);

    if(arr[mid] > num){
        return binarySearch(arr, num, min, mid - 1);
    }
    else if(arr[mid] < num){
        return binarySearch(arr, num, mid + 1, max);
    }
    else{
        return mid;
    }
}