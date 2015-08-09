
namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class StudentsAndWorkers
    {
        static void Main(string[] args)
        {
            List<Student> students = LoadStudents()
                .OrderBy(x => x.Grade)
                .ToList();

            List<Worker> workers = LoadWorkers()
                .OrderByDescending(x => x.MoneyPerHour())
                .ToList();

            Console.WriteLine(String.Join(", ", students) + Environment.NewLine);
            Console.WriteLine(String.Join(", ", workers) + Environment.NewLine);

            var merged = new List<Human>();
            merged.AddRange(students);
            merged.AddRange(workers);
            merged = merged.OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            Console.WriteLine(String.Join(" / ", merged.Select(x => String.Format("{0} {1}", x.FirstName, x.LastName))));
        }

        private static List<Student> LoadStudents()
        {
            List<Student> workers = new List<Student>();

            workers.Add(new Student("Niki", "Kostov", 99.0));
            workers.Add(new Student("Ivo", "Kenov", 97.0));
            workers.Add(new Student("Doncho", "Mini", 98.0));
            workers.Add(new Student("Evlogi", "Hrisi", 96.0));
            workers.Add(new Student("Zdravko", "Gogi", 92.0));
            workers.Add(new Student("Kosta", "Nikolaev", 10.0));
            workers.Add(new Student("Keno", "Ivov", 11.0));
            workers.Add(new Student("Minko", "Donchov", 12.0));
            workers.Add(new Student("Hristian", "Evov", 13.0));
            workers.Add(new Student("Gosho", "Zdravkov", 14.0));

            return workers;
        }

        private static List<Worker> LoadWorkers()
        {
            List<Worker> workers = new List<Worker>();

            workers.Add(new Worker("Nikolay", "Kostov", 1050.0));
            workers.Add(new Worker("Ivaylo", "Kenov", 840.0));
            workers.Add(new Worker("Doncho", "Minkov", 860.0));
            workers.Add(new Worker("Evlogi", "Hristov", 820.0));
            workers.Add(new Worker("Zdravko", "Georgiev", 420.0));
            workers.Add(new Worker("Kosta", "Nikolov", 1051.0));
            workers.Add(new Worker("Keno", "Ivaylov", 841.0));
            workers.Add(new Worker("Minko", "Donkov", 861.0));
            workers.Add(new Worker("Hristo", "Evlogiev", 821.0));
            workers.Add(new Worker("Georgi", "Zdravkov", 421.0));

            return workers;
        }
    }
}
