using Services.Projects;

namespace CompanyKnowledgeBase;

public class Program
{
    static IProjectService projectService = new ProjectService();

    public static async Task Main(string[] args)
    {
        Console.WriteLine("1. Barcha product larni ko'rish");
        Console.WriteLine("2. Id orqali product qidirish");

        int input = Convert.ToInt32(Console.ReadLine());

        switch (input)
        {
            case 1: await ShowAllProduct(); break;
            case 2: break;
        }
    }

    public static async Task ShowAllProduct()
    {
        var products = await projectService.RetriveAllProjectAsync();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}, {product.Name}, {product.Description}, {product.CreatedDate}, {product.UpdatedDate}");
        }
    }
}