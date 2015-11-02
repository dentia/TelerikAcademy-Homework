namespace MusicSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MusicSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MusicSystemDbContext context)
        {
            context.Genres.AddOrUpdate(
                x => x.Name,
                new Genre { Name = "Rap" },
                new Genre { Name = "Bg Rap" },
                new Genre { Name = "Hip Hop" },
                new Genre { Name = "Pop" });

            context.Producers.AddOrUpdate(
                x => x.Name,
                new Producer { Name = "Dr. Dre" },
                new Producer { Name = "Jay Z" },
                new Producer { Name = "Eminem" },
                new Producer { Name = "Drake" });

            context.Countries.AddOrUpdate(
                x => x.Name,
                new Country { Name = "Bulgaria" },
                new Country { Name = "Netherlands" },
                new Country { Name = "USA" },
                new Country { Name = "Germany" });

            context.SaveChanges();

            context.Songs.AddOrUpdate(
                x => x.Name,
                new Song { Year = 1995, Name = "XyZ", GenreId = 1 },
                new Song { Year = 2005, Name = "Some song", GenreId = 2 },
                new Song { Year = 1999, Name = "Melody", GenreId = 2 },
                new Song { Year = 2014, Name = "2014 hit", GenreId = 3 });

            context.Artists.AddOrUpdate(
                x => x.Name,
                new Artist { Name = "Eminem", CountryId = 3 },
                new Artist { Name = "Silent City", CountryId = 1 },
                new Artist { Name = "Some other artist", CountryId = 2 },
                new Artist { Name = "A german dude", CountryId = 4 });

            context.SaveChanges();

            var firstAlbum = new Album { Name = "Album name", ProducerId = 1, Year = 2000 };

            context.Albums.AddOrUpdate(
                x => x.Name,
                firstAlbum,
                new Album { Name = "Another album name", ProducerId = 2, Year = 2004 },
                new Album { Name = "XYZ alb", ProducerId = 3, Year = 2006 },
                new Album { Name = "Can't think of more names", ProducerId = 4, Year = 2009 });

            firstAlbum.Artists.Add(context.Artists.First());
            firstAlbum.Songs.Add(context.Songs.First());

            context.SaveChanges();
        }
    }
}
