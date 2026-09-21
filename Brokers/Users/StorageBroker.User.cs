using Models;
using Dapper;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<IEnumerable<User>> SelectAllUserAsync()
    {
        var querySelectAll = "SELECT * FROM Users;";
        return await dbConnection.QueryAsync<User>(querySelectAll);
    }
    public async Task<User> SelectUserById(int id)
    {
        var querySelectById = "SELECT * FROM Users WHERE Id = @id";
        return await dbConnection.QueryFirstOrDefaultAsync<User>(querySelectById, new { id });
    }
}