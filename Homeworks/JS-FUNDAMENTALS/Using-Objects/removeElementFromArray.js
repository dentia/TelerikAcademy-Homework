// Write a function that removes all elements with a given value
// ? Attach it to the array type

function removeElement(array, element) {
    for (var ind = 0; ind < array.length; ind++) {
        if (array[ind] === element) {
            array.splice(ind, 1);
            --ind;
        }
    }
}

var arr =  [1,2,1,4,1,3,4,1,111,3,2,1,'1'];

console.log(arr);
removeElement(arr, 1);
console.log(arr);