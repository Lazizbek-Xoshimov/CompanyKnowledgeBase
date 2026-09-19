using Models;
using Dapper;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<IEnumerable<User>> SelectAllUserAsync()
    {
        return await dbConnection.QueryAsync<User>("SELECT * FROM Users;");
    }
    public async Task<User> SelectUserById(int id)
    {
        return await dbConnection.QueryFirstOrDefaultAsync<User>($"SELECT * FROM Users WHERE Id = {id}");
    }
}