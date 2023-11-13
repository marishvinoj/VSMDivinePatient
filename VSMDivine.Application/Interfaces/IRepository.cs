namespace VSMDivine.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(int pageSize = 10, int pageNumber = 1);
        Task<T> GetByIdAsync(long id);
        Task<string> AddAsync(T entity);
        Task<string> UpdateAsync(T entity);
        Task<string> DeleteAsync(long id);
    }
}
