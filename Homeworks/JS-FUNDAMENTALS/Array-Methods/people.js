// Write a function for creating persons.
// Each person must have firstname, lastname, age and gender (true is female, false is male)
// Generate an array with ten person with different names, ages and genders

var separator = function () {console.log('-----------------------------')},
    people = Array.apply(null, new Array(10))
        .map(function(_, index){
            return {
                firstName: String.fromCharCode(65 + index % 2) + 'f#' + index,
                lastName: String.fromCharCode(67 + index % 2) + 'l#' + index,
                age: 14 + index,
                isFemale: Boolean(index % 2)};
            }
        );
        people.forEach(function (person) {console.log(person);});
separator();

// Write a function that checks if an array of person contains only people of age (with age 18 or greater)
// Use only array methods and no regular loops (for, while)

console.log('All people are 18 or more years old: ' + people.every(function(person){return person.age >= 18;}));
separator();

// Write a function that prints all underaged persons of an array of person
// Use Array#filter and Array#forEach
// Use only array methods and no regular loops (for, while)

console.log('Underage people: ');

people.filter(function(person){return person.age < 18;})
    .forEach(function (person) {console.log(person);});
separator();

// Write a function that calculates the average age of all females, extracted from an array of persons
// Use Array#filter
// Use only array methods and no regular loops (for, while)

var females = people.filter(function(person) {return person.isFemale;}),
    sum = females.reduce(function (sum, person) {return sum + person.age;}, 0),
    avg = sum / females.length;

console.log('Females: ');
females.forEach(function (person) {console.log(person);});
console.log('Average age: ' + avg);
separator();

// Write a function that finds the youngest male person in a given array of people and prints his full name
// Use only array methods and no regular loops (for, while)
// Use Array#find

console.log('Youngest male: ');

// polyfill by MDN
if (!Array.prototype.find) {
    Array.prototype.find = function(predicate) {
        if (this == null) {
            throw new TypeError('Array.prototype.find called on null or undefined');
        }
        if (typeof predicate !== 'function') {
            throw new TypeError('predicate must be a function');
        }
        var list = Object(this);
        var length = list.length >>> 0;
        var thisArg = arguments[1];
        var value;

        for (var i = 0; i < length; i++) {
            value = list[i];
            if (predicate.call(thisArg, value, i, list)) {
                return value;
            }
        }
        return undefined;
    };
}

function getNamesOfYoungestMale (people) {
    var youngestMale =  people.sort(function (a, b) {return a.age - b.age;})
        .find(function(person) {return !person.isFemale;});

    return youngestMale.firstName + ' ' + youngestMale.lastName +
        '(' + youngestMale.age + ', ' + (youngestMale.isFemale ? 'F' : 'M') + ')';
}

console.log(getNamesOfYoungestMale(people));
separator();

// Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
// Use Array#reduce
// Use only array methods and no regular loops (for, while)

console.log('Groups by first letter of name: ');
var groups = people.reduce(function (gr, person) {
    var letter = person.firstName[0];

    if (gr[letter]) {
        gr[letter].push(person);
    } else {
        gr[letter] = [person];
    }

    return gr;
}, {});

console.log(groups);