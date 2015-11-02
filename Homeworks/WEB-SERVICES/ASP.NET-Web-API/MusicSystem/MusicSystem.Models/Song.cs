namespace MusicSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Songs")]
    public class Song : INameable
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        public int Year { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
    }
}
