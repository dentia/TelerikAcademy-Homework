// Write a function that counts how many times given
// number appears in given array. Write a test function
// to check if the function is working correctly.

console.log(assert([4,4,4,2,2,2,2,4,4,4,1,2,3,4], 4, 7));
console.log(assert([5], 2, 0));
console.log(assert([1,1,1], 1, 3));


function getCount(arr, number){
    var count = 0;

    for(var ind in arr){
        if(arr[ind] === number) ++count;
    }

    return count;
}

function assert(arr, number, expected){
    return getCount(arr, number) == expected;
}