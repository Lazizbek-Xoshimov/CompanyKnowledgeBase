using Models;

namespace Brokers.Projects;

public interface IStorageProject
{
    public Task<IEnumerable<Project>> SelectAllProductAsync();
    public Task<Project> SelectProductById(int id);
}