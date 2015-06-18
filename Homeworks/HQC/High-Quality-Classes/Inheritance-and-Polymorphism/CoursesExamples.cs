namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("HQC", "Nikolay Kostov", new List<string>() { "Peter", "Maria" }, "Enterprise");
            Console.WriteLine(localCourse);
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse("DSA", "Nikolay Kostov", new List<string>() { "Thomas", "Ani", "Steve" }, "Sofia");
            Console.WriteLine(offsiteCourse);
        }
    }
}
