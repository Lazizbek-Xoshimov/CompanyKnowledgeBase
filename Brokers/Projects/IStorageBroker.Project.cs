using Models;

namespace Brokers;

public partial interface IStorageBroker
{
    public Task<IEnumerable<Project>> SelectAllProductAsync();
    public Task<Project> SelectProductById(int projectId);
    public Task<int> GetProductCount();
}