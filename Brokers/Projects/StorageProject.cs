using System.Data;
using Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Brokers.Projects;

public class StorageProject : IStorageProject
{
    private readonly string _connection;
    private readonly IDbConnection dbConnection;

    public StorageProject()
    {
        _connection = "Server=Axion\\MSSQLSERVER01;Database=CompanyKnowledgeBaseDB;Trusted_Connection=True;TrustServerCertificate=True;";
        dbConnection = new SqlConnection(_connection);
    }

    public async Task<IEnumerable<Project>> SelectAllProductAsync()
    {
        return await dbConnection.QueryAsync<Project>("SELECT * FROM Projects;");
    }

    public async Task<Project> SelectProductById(int projectId)
    {
        return await dbConnection.QueryFirstOrDefaultAsync<Project>($"SELECT * FROM Projects WHERE ID = {projectId}");
    }
}