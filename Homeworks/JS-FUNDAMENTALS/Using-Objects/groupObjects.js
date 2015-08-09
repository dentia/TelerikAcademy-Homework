// Write a function that groups an array of persons by
// age, first or last name. The function must return an
// associative array, with keys - the groups, and values -
// arrays with persons in this groups
// ? Use function overloading (i.e. just one function)
// var persons = {…};
// var groupedByFname = group(persons, 'firstname');
// var groupedByAge= group(persons, 'age');

function Person(firstname, lastname, age) {
    if (isNaN(age) || !isFinite(age)) {
        throw new Error('age must be a number');
    }

    if (!(this instanceof  Person)) {
        return new Person(firstname, lastname, age);
    }

    this.firstname = firstname;
    this.lastname = lastname;
    this.age = age;
}

Person.prototype.toString = function() {
    return '(' + this.firstname + ' ' + this.lastname + ',' + this.age + ')';
};

var people = [
    new Person('Nikolay', 'Kostov', 24),
    new Person('Nikolay', 'Hristov', 25),
    new Person('Nikolay', 'Kenov', 30),
    new Person('Ivaylo', 'Kenov', 25),
    new Person('Evlogi', 'Kenov', 25),
    new Person('Evlogi', 'Hristov', 30),
    new Person('Evlogi', 'Kostov', 30),
    new Person('Ivaylo', 'Kostov', 24),
    new Person('Ivaylo', 'Hristov', 24)
];

function group(arr, prop) {
    var group = [];

    for (var ind in arr) {
        var currProp = arr[ind][prop];
        group[currProp] = group[currProp] || [];
        group[currProp].push(arr[ind]);
    }

    return group;
}

function printGroups(prop, arr) {
    console.log(prop);
    for (var key in arr) {
        console.log(arr[key].join('; '));
    }
    console.log();
}

var props = ['firstname', 'lastname', 'age'];

for (var ind in props) {
    var groups = group(people, props[ind]);
    printGroups(props[ind], groups);
}