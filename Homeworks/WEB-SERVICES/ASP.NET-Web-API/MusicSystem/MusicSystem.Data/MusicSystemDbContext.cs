namespace MusicSystem.Data
{
    using System.Data.Entity;

    using Models;

    public class MusicSystemDbContext : DbContext
    {
        public MusicSystemDbContext()
            : base("MusicSystemConnection")
        {
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Producer> Producers { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }
    }
}
