using Order.Infrastructure.Persistence;
using Shared.Base;
using System.Linq;

namespace Order.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly EfCoreDbContext _dbContext;

        public Repository(EfCoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(T item)
        {
            this._dbContext.Set<T>().Add(item);
        }

        public T GetById(long id)
        {
            return this._dbContext.Set<T>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
