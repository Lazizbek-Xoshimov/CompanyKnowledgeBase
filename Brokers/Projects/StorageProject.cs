using Brokers.Connection;
using Models;
using Dapper;

namespace Brokers.Projects;

public class StorageProject : IStorageProject
{
    private readonly DbConnection _connection;    

    public StorageProject()
    {
        _connection = new DbConnection();
    }

    public async Task<IEnumerable<Project>> SelectAllProductAsync()
    {
        return await _connection.GetConnectionObject().QueryAsync<Project>("SELECT * FROM Projects;");
    }

    public async Task<Project> SelectProductById(int projectId)
    {
        return await _connection.GetConnectionObject().QueryFirstOrDefaultAsync<Project>($"SELECT * FROM Projects WHERE ID = {projectId}");
    }

    public async Task<int> GetProductCount()
    {
        return await _connection.GetConnectionObject().QueryFirstOrDefaultAsync<int>("SELECT COUNT(*) FROM Projects;");
    }
}