using Models;

namespace Brokers;

public partial interface IStorageBroker
{
    public Task<IEnumerable<User>> SelectAllUserAsync();
    public Task<User> SelectUserById(int id);
}