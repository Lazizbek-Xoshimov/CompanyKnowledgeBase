using Brokers;
using Models;
using Models.Exceptions;

namespace Services.Projects;

public class ProjectService : IProjectService
{
    private readonly IStorageBroker storageProject;

    public ProjectService()
    {
        storageProject = new StorageBroker();
    }

    public async Task<IEnumerable<Project>> RetriveAllProjectAsync()
    {
        return await storageProject.SelectAllProductAsync();  
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