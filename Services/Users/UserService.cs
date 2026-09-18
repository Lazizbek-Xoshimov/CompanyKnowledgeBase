using Brokers.Users;
using Models;
using Services.Exceptions;

namespace Services.Users;

public class UserService : IUserService
{
    public readonly IStorageUser storageUser;

    public UserService()
    {
        storageUser = new StorageUser();
    }

    public async Task<IEnumerable<User>> RetriveAllUserAsync()
    {
        var users = await storageUser.SelectAllUserAsync();

        if (users.Count().Equals(0))
            throw new NotFoundException($"The Users table is empty.", "");

        return users;
    }

    public async Task<User> RetriveUserById(int userId)
    {
        var user = await storageUser.SelectUserById(userId);

        if (user is null)
            throw new NotFoundException($"{userId} user was not found.", "Use a different Id");

        return user;
    }
}