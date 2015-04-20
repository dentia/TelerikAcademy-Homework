// Write a function that checks if a given object contains
// a given property

var obj = {
    name: 'Ninja',
    age: Math.min(),
    occupation: 'Ninja stuff'
};

console.log(hasProperty(obj, 'occupation'));
console.log(hasProperty(obj, 'gender'));
obj.gender = 'unknown';
console.log(hasProperty(obj, 'gender'));

function hasProperty(obj, prop){
    return obj.hasOwnProperty(prop);
}
