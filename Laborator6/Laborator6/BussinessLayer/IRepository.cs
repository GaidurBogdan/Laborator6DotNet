using System.Linq;

namespace BussinessLayer
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        void Remove(T entity);

        void Add(T entity);

        void Update(T entity);
    }
}
