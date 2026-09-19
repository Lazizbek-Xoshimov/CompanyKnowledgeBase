using System.Data;
using Microsoft.Data.SqlClient;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    private readonly string _connection;
    private readonly IDbConnection dbConnection;

    public StorageBroker()
    {
        _connection = "Server=(localdb)\\MSSQLLocalDB;Database=Company Knowledge Base;Trusted_Connection=True;TrustServerCertificate=True;";
        dbConnection = new SqlConnection(_connection);
    }
}