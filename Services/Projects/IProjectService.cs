using Models;

namespace Services.Projects;

public interface IProjectService
{
    public Task<IEnumerable<Project>> RetriveAllProjectAsync();
    public Task<Project> RetriveProjectById(int id);
}