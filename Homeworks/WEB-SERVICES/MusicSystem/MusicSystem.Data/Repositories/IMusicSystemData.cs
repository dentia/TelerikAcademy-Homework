namespace MusicSystem.Data.Repositories
{
    using Models;

    public interface IMusicSystemData
    {
        IDataRepository<Album> Albums { get; }

        IDataRepository<Artist> Artists { get; }

        IDataRepository<Country> Countries { get; }

        IDataRepository<Genre> Genres { get; }

        IDataRepository<Producer> Producers { get; }

        IDataRepository<Song> Songs { get; }

        int Savechanges();
    }
}
