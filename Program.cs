using Menus;
using Services.Exceptions;

namespace CompanyKnowledgeBase;

public class Program
{
    static UserMenu userMenu = new UserMenu();
    static ProjectMenu projectMenu = new ProjectMenu();

    public static async Task Main(string[] args)
    {
        int input = SelectWithArrow("1. Barcha project larni ko'rish", "2. Id orqali project qidirish",
                        "3. Barcha user larni ko'rish", "4. Id orqali user qidirish");

        try
        {
            switch (input)
            {
                case 1: await projectMenu.ShowAllProjectAsync(); break;
                case 2: await projectMenu.ShowProjectByIdAsync(); break;
                case 3: await userMenu.ShowAllUserAsync(); break;
                case 4: await userMenu.ShowUserByIdAsync(); break;

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