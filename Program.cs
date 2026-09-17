using Services.Projects;

namespace CompanyKnowledgeBase;

public class Program
{
    static IProjectService projectService = new ProjectService();

    public static async Task Main(string[] args)
    {
        Console.WriteLine("1. Barcha product larni ko'rish");
        Console.WriteLine("2. Id orqali product qidirish");

        Console.Write("Tanlov kiriting: ");
        int input = Convert.ToInt32(Console.ReadLine());

        switch (input)
        {
            case 1: await ShowAllProduct(); break;
            case 2: await ShowProductById(); break;
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

    public static async Task ShowProductById()
    {
        Console.Write("Id kiriting: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = await projectService.RetriveProjectById(id);

        Console.WriteLine($"{product.Id}, {product.Name}, {product.Description}, {product.CreatedDate}, {product.UpdatedDate}");
    }
}