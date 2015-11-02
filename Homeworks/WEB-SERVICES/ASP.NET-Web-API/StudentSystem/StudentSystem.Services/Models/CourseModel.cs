namespace StudentSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseModel
    {
        public string CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}