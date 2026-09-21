using Models;
using Dapper;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<bool> InsertUserAsync(User user)
    {
        var queryInsert = "INSERT INTO Users (Id, FirstName, LastName, Email, UserRole, Password, CreatedDate, UpdatedDate) VALUES (@Id, @FirstName, @LastName, @Email, @UserRole, @Password, @CreatedDate, @UpdatedDate)";
        var executedRowCount = await dbConnection.ExecuteAsync(queryInsert, new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, UserRole = user.UserRole, Password = user.PasswordHash, CreatedDate = user.CreatedDate, UpdatedDate = user.UpdatedDate });

        return executedRowCount > 0;
    }

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

    public async Task<bool> UpdateUserAsync(User user)
    {
        var queryUpdate = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, UserRole = @UserRole, Password = @Password, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate";
        var executedRowCount = await dbConnection.ExecuteAsync(queryUpdate, new { Name = user.FirstName, LastName = user.LastName, Email = user.Email, UserRole = user.UserRole, Password = user.PasswordHash, CreatedDate = user.CreatedDate, UpdatedDate = user.UpdatedDate });

        return executedRowCount > 0;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var queryDelete = "DELETE FROM Users WHERE Id = @userId";
        var executedRowCount = await dbConnection.ExecuteAsync(queryDelete, new { Id = userId });

        return executedRowCount > 0;
    }
}