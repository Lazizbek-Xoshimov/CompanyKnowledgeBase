using System.Data;
using Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Brokers.Products;

public class StorageProduct : IStorageProduct
{
    private readonly string _connection;
    private readonly IDbConnection dbConnection;

    public StorageProduct()
    {
        _connection = "Server=Axion\\MSSQLSERVER01;Database=[Company Knowledge Base];Trusted_Connection=True;";
        dbConnection = new SqlConnection(_connection);
    }

    public async Task<IEnumerable<Product>> SelectAllProductAsync()
    {
        return await dbConnection.QueryAsync<Product>("SELECT * FROM Products;");
    }

    public async Task<Product> SelectProductById(int productId)
    {
        return await dbConnection.QueryFirstOrDefaultAsync<Product>($"SELECT * FROM Products WHERE ID = {productId}");
    }
}