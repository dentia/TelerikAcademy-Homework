//A marketing company wants to keep record of its employees. Each record would have the following characteristics:
//First name //Last name //Age (0...100) //Gender (m or f) //Personal ID number (e.g. 8 306 112 507) 
//Unique employee number (27560000…27569999) //Declare the variables needed to keep the information for a 
//single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.

namespace EmployeeData
{
    using System;
    class EmployeeData
    {
        static void Main(string[] args)
        {
            Console.Write("Employee's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Employee's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Employee's age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Employee's gender: ");
            char gender = Console.ReadLine().Trim()[0];
            Console.Write("Employee's number: ");
            int uniqueEmployeeNumber = int.Parse(Console.ReadLine());
            Console.Write("Personal ID: ");
            long personalID = long.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine(@"
Employee:           {0} {1}
Age:                {2}
Gender:             {3}
Employee Number:    {4}
Personal ID:        {5}
", firstName, lastName, age, 
 (gender.ToString().ToUpper() == "M") ? "Male" : "Female", uniqueEmployeeNumber, personalID);
        }
    }
}
