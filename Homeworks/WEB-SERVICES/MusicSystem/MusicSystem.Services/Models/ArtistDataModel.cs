namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ArtistDataModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}