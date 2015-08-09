/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    var Course = {
        init: function(title, presentations) {
            validateTitle(title);
            this.title = title;
            validatePresentations(presentations);
            this.presentations = presentations;
            this.students = [];

            return this;
        },
        addStudent: function(name) {
            var student = validateName(name);
            var id = this.students.length + 1;
            student.id = id;

            this.students.push(student);

            return id;
        },
        getAllStudents: function() {
            return this.students.slice();
        },
        submitHomework: function(studentID, homeworkID) {
            validateId(studentID, 1, this.students.length);
            validateId(homeworkID, 1, this.presentations.length);
        },
        pushExamResults: function(results) {
        },
        getTopStudents: function() {
        }
    };

    Object.defineProperty(Course, 'title', {
       get: function () {
        return Course._title;
       },
        set: function(title){
            Course._title = title;
        }
    });

    Object.defineProperty(Course, 'presentations', {
        get: function () {
            return Course._presentations;
        },
        set: function(presentations){
            Course._presentations = presentations;
        }
    });

    Object.defineProperty(Course, 'students', {
        get: function () {
            return Course._students;
        },
        set: function(students){
            Course._students = students;
        }
    });

    function validateTitle(title){
        if(title === null || typeof title !== 'string'){
            throw 'Invalid type for title.';
        }

        if(title.trim() === '' || title !== title.trim()){
            throw 'Invalid title.';
        }

        if(/[\s]{2,}/.test(title)){
            throw 'Invalid spacing.';
        }
    }

    function validatePresentations(presentations){
        if(presentations === null || !Array.isArray(presentations)){
            throw 'Invalid type for presentations';
        }

        if(presentations.length === 0){
            throw 'Invalid length.';
        }

        presentations.forEach(function (title) {
           validateTitle(title);
        });
    }

    function validateName(name){
        if(name === null || typeof name !== 'string'){
            throw 'Invalid type for name.';
        }

        if(name.trim() === ''){
            throw 'Empty names string.';
        }

        var names = name.split(' ');

        if(names.length !== 2){
            throw 'Invalid names string.';
        }

        names.forEach(function(n){
           if(!/^[A-Z][a-z]*$/.test(n)){
               throw 'Invalid name.';
           }
        });

        return {
          firstname: names[0],
          lastname: names[1]
        };
    }

    function validateId(id, min, max){
        if(id != Number(id)){
            throw 'Invalid type for id.';
        }

        id = +id;

        if(id < min || id > max){
            throw 'Invalid range.';
        }
    }

    return Course;
}