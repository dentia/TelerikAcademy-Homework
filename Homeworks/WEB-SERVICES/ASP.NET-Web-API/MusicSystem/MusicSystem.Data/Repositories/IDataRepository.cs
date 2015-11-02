namespace MusicSystem.Data.Repositories
{
    using System.Linq;

    public interface IDataRepository<T>
    {
        IQueryable<T> All();

        T Find(object id);

        T FindByName(string name);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        int SaveChanges();
    }
}
