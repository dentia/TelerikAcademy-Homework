namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CountryDataModel
    {
        [Required]
        public string Name { get; set; }
    }
}