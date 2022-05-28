using TestWork.Data;

namespace TestWork.Model.Repository;

public interface IRepository<T>
{
    Task<int> AddAsync(T newItem);
    Task<Game?> ReadAsync(int itemId);
    Task<List<Game?>> ReadAllAsync();
    Task<int> UpdateAsync(T item);
    Task<int> DeleteAsync(int itemId);
    
}