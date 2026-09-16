namespace Brokers.Storages;

public interface IStorageBroker<T> where T : class
{
    public Task<IEnumerable<T>> SelectAllAsync<T>();
    public Task<T> SelectByIdAsync<T>(int id);
}