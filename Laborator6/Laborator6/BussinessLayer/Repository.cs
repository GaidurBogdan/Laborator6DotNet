using System.Linq;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer
{
    class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly POIContext _poiContext;

        private DbSet<T> _dbSet => _poiContext.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public GenericRepository(POIContext poiContext)
        {
            _poiContext = poiContext;
        }

        public GenericRepository()
        {
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
