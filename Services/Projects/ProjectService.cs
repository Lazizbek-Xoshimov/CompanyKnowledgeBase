using Brokers.Projects;
using Models;
using Services.Exceptions;

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
            throw new NotFoundException($"The Projects table is empty.", "");
        
        return products;    
    }

    public async Task<Project> RetriveProjectById(int id)
    {
        var productCount = await storageProject.GetProductCount();

        if (id > productCount)
            throw new NotFoundException($"{id} project was not found.", "Use a different Id");

        var product = await storageProject.SelectProductById(id);

        if (product is null)
            throw new NotFoundException($"{id} project was not found.", "Use a different Id");
        
        return product;
    }
}