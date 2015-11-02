namespace MusicSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using MusicSystem.Models;

    public class MusicSystemData : IMusicSystemData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public MusicSystemData()
        {
            this.context = new MusicSystemDbContext();
            this.repositories = new Dictionary<Type, object>();
        }

        public IDataRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IDataRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IDataRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IDataRepository<Genre> Genres
        {
            get
            {
                return this.GetRepository<Genre>();
            }
        }

        public IDataRepository<Producer> Producers
        {
            get
            {
                return this.GetRepository<Producer>();
            }
        }

        public IDataRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public int Savechanges()
        {
            return this.context.SaveChanges();
        }

        private IDataRepository<T> GetRepository<T>() where T : class, INameable
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IDataRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
