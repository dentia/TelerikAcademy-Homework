// Write a function that finds the youngest person in a
// given array of persons and prints his/hers full name
// ? Each person have properties firstname, lastname and
// age, as shown:
// var persons = [
//     { firstname : 'Gosho', lastname: 'Petrov', age: 32 },
//     { firstname : 'Bay', lastname: 'Ivan', age: 81},… ];

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

Person.prototype.toString = function(){
    return this.firstname + ' ' + this.lastname;
};

function comparePeople(a, b) {
    return a.age - b.age;
}

var people = [
    new Person('Nikolay', 'Kostov', 24),
    new Person('Ivaylo', 'Kenov', 25),
    new Person('The', 'Ninja', 0)
];

people.sort(comparePeople);

for (var person = 0; person < people.length; person++) {
	console.log(people[person]);
}

console.log('Youngest: ' + people[0].toString());


