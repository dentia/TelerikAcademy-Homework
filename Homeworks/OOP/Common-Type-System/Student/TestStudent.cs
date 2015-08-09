
namespace Student
{
    using System;
    class TestStudent
    {
        static void Main(string[] args)
        {
            Student student = new Student("Niki", "S", "Kostov", 10002922, "Telerik", "+359 882", "nikolay.kostov@telerik.com");
            student.FillUniversityInfo(Student._University.SofiaUniversity, 4, Student._Faculty.Mathematics, Student._Speciality.IT);
            Console.WriteLine(student.GetHashCode());
            Student student2 = new Student("Ivo", "S", "Kenov", 10034222, "Telerik", "+359 883", "ivaylo.kenov@telerik.com");
            student2.FillUniversityInfo(Student._University.TechnicalUniversity, 4, Student._Faculty.Mathematics, Student._Speciality.IT);
            Console.WriteLine(student2.GetHashCode() + Environment.NewLine);

            Console.WriteLine(student);
            Console.WriteLine(student2);
            Console.WriteLine(student == student2);
            Console.WriteLine(student.Equals(student));
            Console.WriteLine(student.Equals(student2));
            Console.WriteLine(student != student2);
        }
    }
}
