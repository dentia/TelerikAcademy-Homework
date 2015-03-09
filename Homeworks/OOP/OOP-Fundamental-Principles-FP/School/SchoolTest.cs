
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class SchoolTest
    {
        static void Main()
        {
            School school = new School("NPMG");
            List<Discipline> disciplines = LoadDisciplines();
            Teacher dimo = new Teacher("Dimo Padalski", disciplines);

            Course geography = new Course("Geography");
            geography.AddTeacher(dimo);
            school.AddCourse(geography);

            Teacher dimo2 = new Teacher("Dimo Padalski II", disciplines);

            Course geography2 = new Course("Geography2");
            geography2.AddTeacher(dimo2);
            school.AddCourse(geography2);

            Console.WriteLine(PrintSchoolInfo(school));
        }

        private static string PrintSchoolInfo(School school)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(school.Name.ToUpper());

            foreach (var course in school.GetCourses())
            {
                result.AppendLine("* " + course.Name);

                foreach (var teacher in course.GetTeachers())
                {
                    result.AppendLine("  - " + teacher);

                    foreach (var discipline in teacher.GetDisciplines())
                    {
                        result.AppendLine("      " + discipline);
                    }
                }
            }

            return result.ToString();
        }

        private static List<Discipline> LoadDisciplines()
        {
            List<Discipline> disciplines = new List<Discipline>();

            disciplines.Add(new Discipline("Nikolay Kostov", 10000, 12, 12));
            disciplines.Add(new Discipline("Ivaylo Kenov", 10001, 9, 12));
            disciplines.Add(new Discipline("Doncho Minkov", 10002, 12, 9));
            disciplines.Add(new Discipline("Evlogi Hristov", 10003, 11, 11));
            disciplines.Add(new Discipline("Zdravko Georgiev", 10004, 10, 10));

            return disciplines;
        }
    }
}
