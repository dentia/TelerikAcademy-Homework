namespace MusicSystem.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using MusicSystem.Models;

    public class EfRepository<T> : IDataRepository<T> where T : class, INameable
    {
        private readonly DbContext context;
        private readonly IDbSet<T> set;

        public EfRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.ToList().AsQueryable();
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public T FindByName(string name)
        {
            return this.set.FirstOrDefault(x => x.Name == name);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
