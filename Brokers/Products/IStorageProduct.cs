using Models;

namespace Brokers.Products;

public interface IStorageProduct
{
    public Task<IEnumerable<Product>> SelectAllProductAsync();
    public Task<Product> SelectProductById(int id);
}