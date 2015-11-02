namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class StudentInfo
    {
        [Column("Email")]
        public string Email { get; set; }

        [Column("Address")]
        public string Address { get; set; }
    }
}
