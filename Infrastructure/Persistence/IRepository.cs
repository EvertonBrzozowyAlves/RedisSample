namespace RedisCaching.Infrastructure.Persistence;

public interface IRepository<T>
{
    public Task<T?> GetById(Guid id);
    public Task Add(T data);
    public Task<List<T>> GetAll();
}