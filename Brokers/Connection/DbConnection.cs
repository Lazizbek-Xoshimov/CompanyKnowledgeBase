using System.Data;
using Microsoft.Data.SqlClient;

namespace Brokers.Connection;

public class DbConnection
{
    private readonly string _connection;
    private readonly IDbConnection dbConnection;

    public DbConnection()
    {
        _connection = "Server=Axion\\MSSQLSERVER01;Database=CompanyKnowledgeBaseDB;Trusted_Connection=True;TrustServerCertificate=True;";
        dbConnection = new SqlConnection(_connection);
    }

    public IDbConnection GetConnectionObject() => dbConnection;
}