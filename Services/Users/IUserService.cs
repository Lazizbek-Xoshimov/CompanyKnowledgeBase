using Models;

namespace Services.Users;

public interface IUserService
{
    public Task<IEnumerable<User>> RetriveAllUserAsync();
    public Task<User> RetriveUserById(int userId);
}