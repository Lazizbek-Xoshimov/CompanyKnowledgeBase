using Brokers.Connection;
using Dapper;
using Models;

namespace Brokers.Users;

public class StorageUser : IStorageUser
{
    private readonly DbConnection _connection;

    public StorageUser()
    {
        _connection = new DbConnection();
    }

    public async Task<IEnumerable<User>> SelectAllUserAsync()
    {
        return await _connection.GetConnectionObject().QueryAsync<User>("SELECT * FROM Users;");
    }
    public async Task<User> SelectUserById(int id)
    {
        return await _connection.GetConnectionObject().QueryFirstOrDefaultAsync<User>($"SELECT * FROM Users WHERE Id = {id}");
    }
}