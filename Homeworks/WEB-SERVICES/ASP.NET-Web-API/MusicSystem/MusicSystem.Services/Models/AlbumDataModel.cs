namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AlbumDataModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        public int[] SongIds { get; set; }

        [Required]
        public int[] ArtistIds { get; set; }
    }
}