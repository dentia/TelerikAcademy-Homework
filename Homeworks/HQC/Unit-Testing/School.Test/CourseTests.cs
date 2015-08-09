namespace School.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseShoudNotThrowError()
        {
            var course = new Course("HQC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWithNullName()
        {
            var course = new Course(null);
        }

        [TestMethod]
        public void CourseShoulReturnNameCorrectly()
        {
            var course = new Course("HQC");
            Assert.AreEqual("HQC", course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWithEmptyName()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        public void CourseShouldAddStudentCorrectly()
        {
            var course = new Course("HQC");
            var student = new Student("Nikolay Kostov", 10000);
            course.AddStudent(student);

            Assert.AreSame(student, course.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenNullStudentAdded()
        {
            var course = new Course("HQC");
            Student student = null;
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenExistingStudentAdded()
        {
            var course = new Course("HQC");
            Student student = new Student("Nikolay Kostov", 10000); 
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenMoreThanPossibleStudentsAdded()
        {
            var course = new Course("HQC");

            for (int i = 0; i < 50; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + 1));
            }
        }

        [TestMethod]
        public void CourseShouldRemoveStudentCorrectly()
        {
            var course = new Course("HQC");
            var student = new Student("Nikolay Kostov", 10000);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenRemovingNullStudent()
        {
            var course = new Course("HQC");
            Student student = null;
            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenRemovingUnexistingStudent()
        {
            var course = new Course("HQC");
            Student student = new Student("Nikolay Kostov", 10000);
            course.RemoveStudent(student);
        }
    }
}
