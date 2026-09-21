using Menus;
using Models.Exceptions;

namespace CompanyKnowledgeBase;

public class Program
{
    static UserMenu userMenu = new UserMenu();
    static ProjectMenu projectMenu = new ProjectMenu();

    public static async Task Main(string[] args)
    {
        int input = SelectWithArrow("Barcha project larni ko'rish", "Id orqali project qidirish", "Yangi project qo'shish",
                        "Barcha user larni ko'rish", "Id orqali user qidirish");

        try
        {
            switch (input)
            {
                case 1: await projectMenu.ShowAllProjectAsync(); break;
                case 2: await projectMenu.ShowProjectByIdAsync(); break;
                case 3: await projectMenu.AddProjectAsync(); break;
                case 4: await userMenu.ShowAllUserAsync(); break;
                case 5: await userMenu.ShowUserByIdAsync(); break;

                default: Console.WriteLine("Noto'g'ri tanlov kiritildi"); break;
            }
        }
        catch (NotFoundException ex)
        {
            Console.Clear();
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine($"Exception description: {ex.Description}");
        }
        catch (ValidationException ex)
        {
            Console.Clear();
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine($"Exception description: {ex.Description}");
        }
    }

    public static int SelectWithArrow(params IEnumerable<string> informations)
{
    int position = 0;
    ConsoleKeyInfo press;

    do
    {
        Console.Clear();

        for (int i = 0; i < informations.Count(); i++)
        {
            Console.WriteLine($"{(i == position ? ">" : " ")} {informations.ElementAt(i)}");
        }

        press = Console.ReadKey(true);

        if (press.Key == ConsoleKey.DownArrow)
        {
            position++;

            if (position >= informations.Count())
                position = 0;
        }
        else if (press.Key == ConsoleKey.UpArrow)
        {
            position--;

            if (position < 0)
                position = informations.Count() - 1;
        }

    } while (press.Key != ConsoleKey.Enter);

    return position + 1;
}
}