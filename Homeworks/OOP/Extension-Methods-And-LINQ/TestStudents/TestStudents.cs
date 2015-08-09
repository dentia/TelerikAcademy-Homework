
namespace TestStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Stud = Student.Student;
    using Student = Student;
    class TestStudents
    {
        static void Main(string[] args)
        {
            List<Stud> students = new List<Stud>(); 
            LoadStudents(students);
            StringBuilder result = new StringBuilder();

            RunAllTests(students, result);

            Console.WriteLine(result);
        }

        private static void RunAllTests(List<Stud> students, StringBuilder result)
        {
            result.AppendLine("First name before last: " + String.Join(", ", SortedNames(students)) + Environment.NewLine);
            result.AppendLine("Age [18;24]: " + String.Join(", ", AgeInRange(students, 18, 24)) + Environment.NewLine);
            result.AppendLine("Sort names - lambda:" + String.Join(", ", Sort_Lambda(students)));
            result.AppendLine("Sort names - Linq:" + String.Join(", ", Sort_Linq(students)) + Environment.NewLine);
            result.AppendLine("Students from gr.2 - lambda: " + String.Join(", ", SortGroup_Lambda(students, "2")));
            result.AppendLine("Students from gr.2 - Linq: " + String.Join(", ", SortGroup_Linq(students, "2")) + Environment.NewLine);
            result.AppendLine("Email at abv - lambda: " + String.Join(", ", Email_Linq(students, "abv.bg")));
            result.AppendLine("Email at abv - Linq: " + String.Join(", ", Email_String(students, "abv.bg")) + Environment.NewLine);
            result.AppendLine("Phones in Sofia: " + String.Join(", ", Phone_Linq(students, "(02)")) + Environment.NewLine);
            result.AppendLine("All students with mark 6: " + String.Join(", ", Marks_Linq(students, 6.0)) + Environment.NewLine);
            result.AppendLine("All students with exactly 2 marks: " + String.Join(", ", MarksCount_Linq(students, 2)) + Environment.NewLine);
            result.AppendLine("All marks from 2006" + String.Join(", ", MarksInYear_Linq(students, "06")) + Environment.NewLine);
            result.AppendLine("All tudents from FMI department" + String.Join(", ", SelectDepartment_Linq(students, "FMI")) + Environment.NewLine);
            result.AppendLine("Group students by gr. num: - Linq: " + String.Join(" / ", GroupByGroups_Linq(students)));
            result.AppendLine("Group students by gr. num: - lamda: " + String.Join(" / ", GroupByGroups_Lambda(students)));
        }

        private static IEnumerable<string> GroupByGroups_Lambda(List<Stud> students)
        {
            //Console.WriteLine(String.Join(" / ", GroupByGroups_Linq(students)));
            var groups = students.GroupBy(x => x.AttendedGroup.GroupNumber);

            var result = new List<string>();
            foreach (var group in groups)
            {
                result.Add(String.Format("group {0}: {1}",
                    group.ElementAt(0).AttendedGroup.GroupNumber, String.Join(", ", group)));
            }
            return result;
        }

        private static IEnumerable<string> GroupByGroups_Linq(List<Stud> students)
        {
            var groups = from stud in students
                         group stud by stud.AttendedGroup.GroupNumber;

            var result = new List<string>();
            foreach (var group in groups)
            {
                result.Add(String.Format("group {0}: {1}", 
                    group.ElementAt(0).AttendedGroup.GroupNumber, String.Join(", ", group)));
            }
            return result;
        }

        private static IEnumerable<Stud> SelectDepartment_Linq(List<Stud> students, string department)
        {
            //* Create a class Group with properties GroupNumber and DepartmentName. 
            //Introduce a property Group in the Student class. Extract all students from 
            //"Mathematics" department. Use the Join operator.

            return from stud in students
                   where stud.AttendedGroup.Department == department
                   orderby stud.FirstName
                   select stud;
        }

        private static IEnumerable<double> MarksInYear_Linq(List<Stud> students, string year)
        {
            //Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 last digits in the FN).
            var marks = from stud in students
                        where stud.FacultyNumber.EndsWith(year)
                        select stud.Marks;

            var result = new List<double>();
            foreach (var stud in marks)
            {
                result.AddRange(stud);
            }

            return result;
        }

        private static IEnumerable<string> MarksCount_Linq(List<Stud> students, int count)
        {
            //Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.

            var studs = from stud in students
                        where stud.Marks.Count == count
                        select new { StudentName = String.Format("{0} {1}", stud.FirstName, stud.LastName), Marks = stud.Marks };

            var result = new List<string>();

            foreach (var student in studs)
            {
                result.Add(String.Format("{0}: {1}", student.StudentName, String.Join(", ", student.Marks)));
            }
            return result;
        }

        private static IEnumerable<string> Marks_Linq(List<Stud> students, double mark)
        {
            //Select all students that have at least one mark Excellent (6) 
            //into a new anonymous class that has properties – FullName and Marks. Use LINQ.
            var studs = from stud in students
                        where stud.Marks.Contains(mark)
                        select new 
                        {StudentName = String.Format("{0} {1}", stud.FirstName, stud.LastName), Marks = stud.Marks};

            var result = new List<string>();

            foreach (var student in studs)
            {
                result.Add(String.Format("{0}: {1}", student.StudentName, String.Join(", ", student.Marks)));
            }
            return result;
        }

        private static IEnumerable<Stud> Phone_Linq(List<Stud> students, string phoneGroup)
        {
            return from stud in students
                   where stud.Phone.Contains(phoneGroup)
                   orderby stud.FirstName
                   select stud;
        }

        private static IEnumerable<Stud> Email_String(List<Stud> students, string host)
        {
            //Extract all students that have email in abv.bg. Use string methods and LINQ.
            return students
                .Where(
                        x => x.Email.ToString()
                            .Substring(x.Email.ToString().IndexOf("@") + 1) 
                        == host)
                .OrderBy(x => x.FirstName).ToArray();
        }

        private static IEnumerable<Stud> Email_Linq(List<Stud> students, string host)
        {
            return from stud in students
                   where stud.Email.Host == host
                   orderby stud.FirstName
                   select stud;
        }

        private static IEnumerable<Stud> SortGroup_Lambda(List<Stud> students, string group)
        {
            //Implement the previous using the same query expressed with extension methods.

            return students.Where(x => x.AttendedGroup.GroupNumber == group)
                .OrderBy(x => x.FirstName)
                .ToArray();
        }

        private static IEnumerable<Stud> SortGroup_Linq(List<Stud> students, string gr)
        {
            //Select only the students that are from group number 2. 
            //Use LINQ query. Order the students by FirstName.

            return from stud in students
                   where stud.AttendedGroup.GroupNumber == gr
                   orderby stud.FirstName
                   select stud;
        }

        private static IEnumerable<Stud> Sort_Linq(List<Stud> students)
        {
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions 
            //sort the students by first name and last name in descending order. 
            //Rewrite the same with LINQ.

            return from stud in students 
                   orderby stud.FirstName descending, 
                   stud.LastName descending 
                   select stud;
        }

        private static IEnumerable<Stud> Sort_Lambda(List<Stud> students)
        {
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions 
            //sort the students by first name and last name in descending order.

            return students
                .Select(x => x)
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .ToArray();
        }

        private static IEnumerable<Stud> AgeInRange(List<Stud> students, int min, int max)
        {
            //Write a LINQ query that finds the first name and 
            //last name of all students with age between 18 and 24.

            return from stud in students
                   where (stud.Age >= min && stud.Age <= max)
                   select stud;
        }

        private static IEnumerable<Stud> SortedNames(List<Stud> students)
        {
            //Write a method that from a given array of students finds 
            //all students whose first name is before its last name alphabetically. 
            //Use LINQ query operators.

            return from stud in students
                   where FirstNameBeforeLast(stud.FirstName, stud.LastName)
                   select stud;
        }

        private static bool FirstNameBeforeLast(string first, string last)
        {
            return String.CompareOrdinal(first.ToUpper(), last.ToUpper()) < 0;
        }

        private static void LoadStudents(List<Stud> students)
        {

            students.Add(new Stud("Niki", "Kostov", 24, "+359 (02) 882",
                "ni.ki@abv.bg", "011106", new Student.Group("FMI", "2")));
            students[0].AddMarks(6.0, 5.0, 4.0);
            students.Add(new Stud("Ivo", "Kenov", 25, "00359 (02) 883",
                "ivo.k@gmail.com", "011206", new Student.Group("FMI", "2")));
            students[1].AddMarks(6.0, 5.0, 4.0);
            students.Add(new Stud("Doncho", "Minkov", 17, "+359 (02) 884",
                "do.do.doncho@abv.bg", "011306", new Student.Group("FMI", "3")));
            students[2].AddMarks(6.0, 5.0);
            students.Add(new Stud("Kaka", "Minka", 22, "00359 (032) 885",
                "ka_ka_ta@gbg.bg", "011406", new Student.Group("FMI", "3")));
            students[3].AddMarks(5.0, 4.0);
        }
    }
}
