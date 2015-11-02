namespace StudentSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StudentModel
    {
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}