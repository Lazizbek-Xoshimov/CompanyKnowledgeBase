using Brokers;
using Models;
using Models.Exceptions;

namespace Services.Users;

public class UserService : IUserService
{
    public readonly IStorageBroker storageUser;

    public UserService()
    {
        storageUser = new StorageBroker();
    }

    public async Task<IEnumerable<User>> RetriveAllUserAsync()
    {
        return await storageUser.SelectAllUserAsync();
    }

    public async Task<User> RetriveUserById(int userId)
    {
        var user = await storageUser.SelectUserById(userId);

        if (user is null)
            throw new NotFoundException($"{userId} user was not found.", "Use a different Id");

        return user;
    }
}