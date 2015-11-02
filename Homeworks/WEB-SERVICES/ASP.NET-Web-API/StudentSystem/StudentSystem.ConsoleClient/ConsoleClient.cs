namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Models;
    
    public class ConsoleClient
    {
        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName);
            }
        }

        public static void Main()
        {
            var data = new StudentsSystemData();

            var courses = data.Courses.All();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            data.Courses.Add(new Course
            {
                Name = "Repo Pattern",
                Description = "Cool"
            });

            data.SaveChanges();

            var students = data.Students.All();

            Console.WriteLine(students.Count());

            var masters = data.Students.SearchFor(st => st.Level > 1);
            PrintStudents(masters);

            var ivaylos = data.Students.SearchFor(st => st.FirstName == "Ivaylo");
            PrintStudents(ivaylos);

            var firstMaster = data.Students.SearchFor(st => st.Level == -5).FirstOrDefault();
            if (firstMaster == null)
            {
                Console.WriteLine("NULL");
            }

            var levels = data.Students.All().Select(st => new
                {
                    Level = st.Level,
                    LastName = st.LastName
                });

            foreach (var level in levels)
            {
                Console.WriteLine(level.LastName);
            }

            var orderedStudents = data.Students
                .All()
                .OrderBy(st => st.LastName)
                .ThenBy(st => st.Level);

            PrintStudents(orderedStudents);

            var someQuery = data.Students
                .All()
                .Where(st => st.Level > 0)
                .OrderBy(st => st.LastName)
                .Select(st => new
                {
                    FirstName = st.FirstName
                });

            var maxLevel = data.Students.All().Max(st => st.Level);

            Console.WriteLine(maxLevel);
            
            data.Courses.Add(new Course
            {
                Name = "Entity Framework",
                Description = "Code First"
            });

            data.SaveChanges();

            var entityFrCourse = data.Courses.SearchFor(c => c.Name == "Entity Framework").FirstOrDefault();

            foreach (var master in masters)
            {
                 entityFrCourse.Students.Add(master);
            }

            data.SaveChanges();

            var activeCourses = data.Courses.SearchFor(c => c.Students.Count() > 0);

            foreach (var course in activeCourses)
            {
                course.Description = "Code First Is Cool";
                Console.WriteLine(course.Name);
            }

            data.SaveChanges();
        }
    }
}
