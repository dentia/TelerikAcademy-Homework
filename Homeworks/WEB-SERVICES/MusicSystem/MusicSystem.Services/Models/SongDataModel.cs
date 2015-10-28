namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SongDataModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}