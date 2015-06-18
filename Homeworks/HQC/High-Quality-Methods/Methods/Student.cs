namespace Methods
{
    using System;

    /// <summary>
    /// Class for students, containing basic information (names, birthdate) and age comparer
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Construcotr for the class Student
        /// </summary>
        /// <param name="firstName">String - Student's first name</param>
        /// <param name="lastName">String - Student's last name</param>
        /// <param name="birthDate">DateTime - Student's birth date</param>
        /// <param name="town">String - Student's home town</param>
        /// <param name="comments">String - Comments about the student</param>
        public Student(string firstName, string lastName, DateTime birthDate, string town, string comments = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Comments = comments;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Town { get; set; }

        public string Comments { get; set; }

        /// <summary>
        /// The method compares two students by their birth date.
        /// </summary>
        /// <returns>Boolean variable - true if the first students is older than the second, false - otherwise</returns>
        public bool IsOlderThan(Student other)
        {
            return this.BirthDate < other.BirthDate;
        }
    }
}
