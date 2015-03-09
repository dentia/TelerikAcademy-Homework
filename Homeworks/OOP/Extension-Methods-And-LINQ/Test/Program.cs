using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ExtensionMethods;
using Stud = Student.Student;
using Grade = Student.Mark;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder_Extension();
            IEnumerable_Extensions();
            QueryStudents();
        }

        private static void QueryStudents()
        {
            List<Stud> students = GetStudents();
            Console.WriteLine(String.Join(Environment.NewLine, FirstNamePreceding(students)));
            Console.WriteLine(String.Join(Environment.NewLine, AgeInRange(students, 18, 24)));
        }

        private static IEnumerable<Stud> AgeInRange(List<Stud> students, int min, int max)
        {
            //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.


            var studs = from stud in students
                        where (stud.Age >= min && stud.Age <= max)
                        select stud;

            return studs;
        }

        private static IEnumerable<Stud> FirstNamePreceding(List<Stud> students)
        {
            //Write a method that from a given array of students finds all students whose 
            //first name is before its last name alphabetically. Use LINQ query operators.

            var studs = from stud in students
                        where FirstBeforeLast(stud.FirstName, stud.LastName)
                        select stud;

            return studs;
        }

        private static bool FirstBeforeLast(string first, string last)
        {
            return String.CompareOrdinal(first.ToUpper(), last.ToUpper()) < 0;
        }

        private static List<Stud> GetStudents()
        {
            List<Stud> students = new List<Stud>();

            students.Add(new Stud("Nikolay", "Kostov", 24, "+359 882", "academy@telerik.com", "1"));
            students[0].AddMark("C#2", 6.0);
            students[0].AddMark("C#1", 5.99);
            students[0].AddMarks(new Grade("OOP", 4.20), new Grade("HTML", 5.20));
            students.Add(new Stud("Ivaylo", "Kenov", 25, "+359 883", "ivaylo.kenov@abv.bg", "11"));
            students[1].AddMark("C#2", 5.40);
            students[1].AddMark("C#1", 6.00);
            students[1].AddMark("OOP", 4.0);
            students[1].AddMark("HTML", 5.99);
            students.Add(new Stud("Spas", "Tonev", 19, "+359 884", "spas.t@abv.bg", "111"));
            students.Add(new Stud("Lilly", "Iskrova", 22, "+359 885", "li.is.ly@abv.bg", "1111"));
            students.Add(new Stud("Nelly", "Velkova-Ivanova", 20, "+359 886", "nelly.velly@gmail.com", "11111"));

            return students;
        }

        private static void StringBuilder_Extension()
        {
            StringBuilder sb = new StringBuilder("Only THIS will remain after the substring.");
            Console.WriteLine(sb);
            sb = sb.Substring(5, 4);
            Console.WriteLine(sb);
        }

        private static void IEnumerable_Extensions()
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);

            Console.WriteLine("Max: {0}", numbers.Min());
            Console.WriteLine("Min: {0}", numbers.Max());
            Console.WriteLine("Sum: {0}", numbers.Sum());
            Console.WriteLine("Product: {0}", numbers.Product());
        }
    }
}