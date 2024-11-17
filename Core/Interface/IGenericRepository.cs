using Core.Entities;


namespace Core.Interface
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();

        void add(T entity);
        void update(T entity);
        void remove(T entity);

        Task<bool> SaveAllAsync();
        bool Exists(int id);
    }
}


