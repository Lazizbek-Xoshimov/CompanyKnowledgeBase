using Dapper;
using Models;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<IEnumerable<Project>> SelectAllProductAsync()
    {
        return await dbConnection.QueryAsync<Project>("SELECT * FROM Projects;");
    }

    public async Task<Project> SelectProductById(int projectId)
    {
        return await dbConnection.QueryFirstOrDefaultAsync<Project>($"SELECT * FROM Projects WHERE ID = {projectId}");
    }

    public async Task<int> GetProductCount()
    {
        return await dbConnection.QueryFirstOrDefaultAsync<int>("SELECT COUNT(*) FROM Projects;");
    }
}