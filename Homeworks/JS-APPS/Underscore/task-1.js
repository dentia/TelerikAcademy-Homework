
/* 
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName` and `lastName` properties
*   **Finds** all students whose `firstName` is before their `lastName` alphabetically
*   Then **sorts** them in descending order by fullname
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   Then **prints** the fullname of founded students to the console
*   **Use underscore.js for all operations**
*/

function solve(){
    return function (students) {
        _.chain(students)
            .filter(function(person){
                return person.lastName > person.firstName;
            })
            .map(function(person){
                person.fullName = person.firstName + ' ' + person.lastName;
                return person;
            })
            .sortBy('fullName')
            .reverse()
            .each(function(person){
                console.log(person.fullName)
            });
    };
}

module.exports = solve;

