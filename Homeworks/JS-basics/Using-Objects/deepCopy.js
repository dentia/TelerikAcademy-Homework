// Write a function that makes a deep copy of an object
// ? The function should work for both primitive and
// reference types

console.log(clone(5));
console.log(clone({name: 'Ninja', age: Math.min()}));

function clone(obj){
    if(typeof obj !== 'object'){
        return obj;
    }

    var cloned = {};
    for(var prop in obj){
        cloned[prop] = clone(obj[prop]);
    }

    return cloned;
}