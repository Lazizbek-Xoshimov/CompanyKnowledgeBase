    using Models;

    namespace Brokers.Users;

    public interface IStorageUser
    {
        public Task<IEnumerable<User>> SelectAllProductAsync();
        public Task<User> SelectProductById(int id);
    }