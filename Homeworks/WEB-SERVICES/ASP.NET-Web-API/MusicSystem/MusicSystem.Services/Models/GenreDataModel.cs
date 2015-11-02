namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GenreDataModel
    {
        [Required]
        public string Name { get; set; }
    }
}