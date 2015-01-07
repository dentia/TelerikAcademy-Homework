//A company has name, address, phone number, fax number, web site and manager. 
//The manager has first name, last name, age and a phone number.
//Write a program that reads the information about a company and its manager and prints it back on the console.

namespace PrintCompanyInfo
{
    using System;
    class PrintCompanyInfo
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.FillCompanyInfo();

            Console.Clear();
            Console.WriteLine(company);

//Telerik Academy
//231 Al. Malinov, Sofia
//+359 888 55 55 555

//http://telerikacademy.com/
//Nikolay
//Kostov
//25
//+359 2 981 981
        }
    }
}
