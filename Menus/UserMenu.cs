using Services.Users;

namespace Menus;

public class UserMenu
{
     IUserService userService;

    public UserMenu()
    {
        userService = new UserService();
    }

    public async Task ShowAllUserAsync()
    {
        var users = await userService.RetriveAllUserAsync();

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id}, {user.FirstName}, {user.LastName}");
        }
    }

    public async Task ShowUserByIdAsync()
    {
        Console.Write("User ning Id sini kiriting: ");
        int userId = Convert.ToInt32(Console.ReadLine());

        var user = await userService.RetriveUserById(userId);

        Console.WriteLine($"{user.Id}, {user.FirstName}, {user.LastName}, {user.Email}, {user.UserRole}, {user.PasswordHash}, {user.CreatedDate}, {user.UpdatedDate}");
    }
}