namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProducerDataModel
    {
        [Required]
        public string Name { get; set; }
    }
}