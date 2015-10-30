namespace MusicSystem.Data
{
    using System.Data.Entity;

    using Migrations;
    using Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class MusicSystemDbContext : DbContext
    {
        public MusicSystemDbContext()
            : base("MusicSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, Configuration>());
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Producer> Producers { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }
    }
}
