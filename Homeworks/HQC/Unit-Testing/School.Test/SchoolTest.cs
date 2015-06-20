namespace School.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolShouldNotThrowException()
        {
            var school = new School("Telerik Academy");
        }

        [TestMethod]
        public void SchoolShouldReturnNameCorrectly()
        {
            var school = new School("Telerik Academy");
            Assert.AreEqual("Telerik Academy", school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNameIsNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNameIsEmpty()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        public void SchoolShouldAddStudentCorrectly()
        {
            var school = new School("Telerik Academy");
            var student = new Student("Nikolay Kostov", 10000);
            school.AddStudent(student);
            Assert.AreSame(student, school.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNullStudentAdded()
        {
            var school = new School("Telerik Academy");
            Student student = null;
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenAddingExistingStudent()
        {
            var school = new School("Telerik Academy");
            var student = new Student("Nikolay Kostov", 10000);
            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolShouldThrowExceptionWhenAddingStudentWithDuplicateId()
        {
            var school = new School("Telerik Academy");
            var student = new Student("Nikolay Kostov", 10000);
            var otherStudent = new Student("Doncho Minkov", 10000);
            school.AddStudent(student);
            school.AddStudent(otherStudent);
        }

        [TestMethod]
        public void SchoolShouldAddCourseCorrectly()
        {
            var school = new School("Telerik Academy");
            var course = new Course("HQC");
            school.AddCourse(course);
            Assert.AreSame(course, school.Courses.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNullCourseAdded()
        {
            var school = new School("Telerik Academy");
            Course course = null;
            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenExistingCourseAdded()
        {
            var school = new School("Telerik Academy");
            var course = new Course("HQC");
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void SchoolShouldRemoveStudentCorrectly()
        {
            var school = new School("Telerik Academy");
            var student = new Student("Nikolay Kostov", 10000);
            school.AddStudent(student);
            school.RemoveStudent(student);
            Assert.IsTrue(school.Students.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenRemovingNullStudent()
        {
            var school = new School("Telerik Academy");
            Student student = null;
            school.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenRemovingNotExistingStudent()
        {
            var school = new School("Telerik Academy");
            var student = new Student("Nikolay Kostov", 10000);
            school.RemoveStudent(student);
        }

        [TestMethod]
        public void SchoolShouldRemoveCourseCorrectly()
        {
            var school = new School("Telerik Academy");
            var course = new Course("HQC");
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.IsTrue(school.Courses.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenRemovingNullCourse()
        {
            var school = new School("Telerik Academy");
            Course course = null;
            school.RemoveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenRemovingNotExistingCourse()
        {
            var school = new School("Telerik Academy");
            var course = new Course("HQC");
            school.RemoveCourse(course);
        }
    }
}
