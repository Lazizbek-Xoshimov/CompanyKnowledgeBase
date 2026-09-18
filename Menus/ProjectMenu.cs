using Services.Projects;

namespace Menus;

public class ProjectMenu
{
    static IProjectService projectService;

    public ProjectMenu()
    {
        projectService = new ProjectService();
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
}