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

    public async Task<bool> AddProjectAsync(Project project)
    {
        var projects = await RetriveAllProjectAsync();

        if (projects.Select(p => p.Id).Contains(project.Id))
            throw new ValidationException($"{project.Id} user is exsits.", "Use another user Id.");

        return await storageProject.InsertProjectAsync(project);
    }

    public async Task<IEnumerable<Project>> RetriveAllProjectAsync()
    {
        return await storageProject.SelectAllProjectAsync();  
    }

    public async Task<Project> RetriveProjectById(int id)
    {
        var productCount = await storageProject.GetProjectCount();

        if (id > productCount)
            throw new NotFoundException($"{id} project was not found.", "Use a different Id");

        var product = await storageProject.SelectProjectById(id);

        if (product is null)
            throw new NotFoundException($"{id} project was not found.", "Use a different Id");
        
        return product;
    }

    public Task<bool> UpdateProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProjectAsync(int projectId)
    {
        throw new NotImplementedException();
    }
}