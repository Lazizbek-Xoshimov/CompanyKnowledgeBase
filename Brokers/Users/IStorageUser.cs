    using Models;

    namespace Brokers.Users;

    public interface IStorageUser
    {
        public Task<IEnumerable<User>> SelectAllUserAsync();
        public Task<User> SelectUserById(int id);
    }