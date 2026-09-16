namespace Brokers.Storages;

public class StorageBroker<T> : IStorageBroker<T>
{
    public async Task<IEnumerable<T>> SelectAllAsync<T>()
    {
        throw new NotImplementedException();
    }

    public async Task<T> SelectByIdAsync<T>(int id)
    {
        throw new NotImplementedException();
    }
}