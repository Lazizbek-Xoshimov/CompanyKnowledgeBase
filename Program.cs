using Services.Projects;
using Services.Users;

namespace CompanyKnowledgeBase;

public class Program
{
    static IProjectService projectService = new ProjectService();
    static IUserService userService = new UserService();

    public static async Task Main(string[] args)
    {
        Console.WriteLine("Projects");
        Console.WriteLine("1. Barcha project larni ko'rish");
        Console.WriteLine("2. Id orqali project qidirish");
        Console.WriteLine("\nUsers");
        Console.WriteLine("3. Barcha user larni ko'rish");
        Console.WriteLine("4. Id orqali user qidirish");

        Console.Write("Tanlov kiriting: ");
        int input = Convert.ToInt32(Console.ReadLine());

        switch (input)
        {
            case 1: await ShowAllProjectAsync(); break;
            case 2: await ShowProjectByIdAsync(); break;
            case 3: await ShowAllUserAsync(); break;
            case 4: await ShowUserByIdAsync(); break;

            default: Console.WriteLine("Noto'g'ri tanlov kiritildi"); break;
        }
    }

    public static async Task ShowAllProjectAsync()
    {
        var products = await projectService.RetriveAllProjectAsync();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}, {product.Name}");
        }
    }

    public static async Task ShowProjectByIdAsync()
    {
        Console.Write("Project ning Id sini kiriting: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = await projectService.RetriveProjectById(id);

        Console.WriteLine($"{product.Id}, {product.Name}, {product.Description}, {product.CreatedDate}, {product.UpdatedDate}");
    }

    public static async Task ShowAllUserAsync()
    {
        var users = await userService.RetriveAllUserAsync();

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id}, {user.FirstName}, {user.LastName}");
        }
    }

    public static async Task ShowUserByIdAsync()
    {
        Console.Write("User ning Id sini kiriting: ");
        int userId = Convert.ToInt32(Console.ReadLine());

        var user = await userService.RetriveUserById(userId);

        Console.WriteLine($"{user.Id}, {user.FirstName}, {user.LastName}, {user.Email}, {user.UserRole}, {user.PasswordHash}, {user.CreatedDate}, {user.UpdatedDate}");
    }
}