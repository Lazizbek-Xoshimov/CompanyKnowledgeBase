using Brokers.Projects;
using Models;

namespace Services.Projects;

public class ProjectService : IProjectService
{
    private readonly IStorageProject storageProject;

    public ProjectService()
    {
        storageProject = new StorageProject();
    }

    public async Task<IEnumerable<Project>> RetriveAllProjectAsync()
    {
        var products = await storageProject.SelectAllProductAsync();

        if (products.Count().Equals(0))
            throw new Exception("Not found!");
        
        return products;
    }

    public async Task<Project> RetriveProjectById(int id)
    {
        var productCount = await storageProject.GetProductCount();

        if (id > productCount)
            throw new Exception("Not found!");

        var product = await storageProject.SelectProductById(id);

        if (product is null)
            throw new Exception("Not found!");
        
        return product;
    }
}