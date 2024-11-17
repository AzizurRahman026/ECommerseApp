

using Core.Entities;
using Core.Interface;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MongoDbContext context;
        public GenericRepository(MongoDbContext _context)
        {
            context = _context;
        }


        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }
        public void add(T entity)
        {
            throw new NotImplementedException();
        }

        public void update(T entity)
        {
            throw new NotImplementedException();
        }
        public void remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
