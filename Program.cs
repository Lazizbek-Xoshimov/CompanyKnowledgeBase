using Menus;

namespace CompanyKnowledgeBase;

public class Program
{
    public static async Task Main(string[] args)
    {
        UserMenu userMenu = new UserMenu();
        ProjectMenu projectMenu = new ProjectMenu();

        Console.WriteLine("Projects");
        Console.WriteLine("1. Barcha project larni ko'rish");
        Console.WriteLine("2. Id orqali project qidirish");
        Console.WriteLine("\nUsers");
        Console.WriteLine("3. Barcha user larni ko'rish");
        Console.WriteLine("4. Id orqali user qidirish");

        try
        {
            Console.Write("Tanlov kiriting: ");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1: await projectMenu.ShowAllProjectAsync(); break;
                case 2: await projectMenu.ShowProjectByIdAsync(); break;
                case 3: await userMenu.ShowAllUserAsync(); break;
                case 4: await userMenu.ShowUserByIdAsync(); break;

                default: Console.WriteLine("Noto'g'ri tanlov kiritildi"); break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}