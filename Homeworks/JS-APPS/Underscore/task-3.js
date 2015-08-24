/* 
 Create a function that:
 *   Takes an array of students
 *   Each student has:
 *   `firstName`, `lastName` and `age` properties
 *   Array of decimal numbers representing the marks
 *   **finds** the student with highest average mark (there will be only one)
 *   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve(){
    return function (students) {
        var student = _.chain(students)
            .map(function(person){
                person.fullName = person.firstName + ' ' + person.lastName;

                person.averageGrade = (_.reduce(person.marks, function(base, mark){
                    return base + mark;
                }, 0)) / person.marks.length;

                return person;
            })
            .sortBy(function(person){
                return -person.averageGrade;
            })
            .first()
            .value();

        console.log(student.fullName + ' has an average score of ' + student.averageGrade);
    };
}

module.exports = solve;
