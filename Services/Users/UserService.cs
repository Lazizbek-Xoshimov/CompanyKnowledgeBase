using Brokers.Users;
using Models;

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
            throw new Exception("User is not found.");

        return users;
    }

    public async Task<User> RetriveUserById(int userId)
    {
        var user = await storageUser.SelectUserById(userId);

        if (user is null)
            throw new Exception("User is not found.");

        return user;
    }
}