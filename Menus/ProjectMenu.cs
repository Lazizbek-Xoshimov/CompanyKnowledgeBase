using Models;
using Services.Projects;

namespace Menus;

public class ProjectMenu
{
    static IProjectService projectService;

    public ProjectMenu()
    {
        projectService = new ProjectService();
    }

    public async Task AddProjectAsync()
    {
        Project project = new Project();

        Console.Write("Project Id = ");
        project.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Project Name = ");
        project.Name = Console.ReadLine();
        
        Console.Write("Description = ");
        project.Description = Console.ReadLine();

        Console.Write("Created User Id of Project = ");
        project.CreatedByUserId = Convert.ToInt32(Console.ReadLine());
        
        project.CreatedDate = DateTime.Now;
        project.UpdatedDate = DateTime.Now;

        var isAdded = await projectService.AddProjectAsync(project);

        if (isAdded)
            Console.WriteLine("Project added.");
    }

    public async Task ShowAllProjectAsync()
    {
        var products = await projectService.RetriveAllProjectAsync();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}, {product.Name}");
        }
    }

    public async Task ShowProjectByIdAsync()
    {
        Console.Write("Project ning Id sini kiriting: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = await projectService.RetriveProjectById(id);

        Console.WriteLine($"{product.Id}, {product.Name}, {product.Description}, {product.CreatedDate}, {product.UpdatedDate}");
    }

    public async Task UpdateProjectMenuAsync()
    {
        Project project = new Project();

        Console.Write("Project Id = ");
        project.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Project Name = ");
        project.Name = Console.ReadLine();
        
        Console.Write("Description = ");
        project.Description = Console.ReadLine();

        Console.Write("Created User Id of Project = ");
        project.CreatedByUserId = Convert.ToInt32(Console.ReadLine());
        
        project.UpdatedDate = DateTime.Now;

        var isUpdated = await projectService.UpdateProjectAsync(project);

        if (isUpdated)
            Console.WriteLine("Project updated.");
    }

    public async Task DeleteProjectMenuAsync()
    {
        Console.Write("Project ning Id sini kiriting: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var isDeleted = await projectService.DeleteProjectAsync(id);

        if (isDeleted)
            Console.WriteLine("Project deleted.");
    }
}