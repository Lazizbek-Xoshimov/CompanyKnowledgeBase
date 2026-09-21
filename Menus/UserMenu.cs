using Models;
using Models.Enums;
using Services.Users;

namespace Menus;

public class UserMenu
{
     IUserService userService;

    public UserMenu()
    {
        userService = new UserService();
    }

    public async Task AddUserAsync()
    {
        User user = new User();

        Console.Write("User Id = ");
        user.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("User FirstName = ");
        user.FirstName = Console.ReadLine();

        Console.Write("User LastName = ");
        user.LastName = Console.ReadLine();

        Console.Write("User Email = ");
        user.Email = Console.ReadLine();
        
        Console.Write("User Role = ");
        user.UserRole = Enum.Parse<UserRole>(Console.ReadLine());

        Console.Write("User Password = ");
        user.PasswordHash = Console.ReadLine();
        
        user.CreatedDate = DateTime.Now;
        user.UpdatedDate = DateTime.Now;

        var isAdded = await userService.AddUserAsync(user);

        if (isAdded)
            Console.WriteLine("User added.");
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

    public async Task UpdateUserMenuAsync()
    {
        User user = new User();

        Console.Write("User Id = ");
        user.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("User FirstName = ");
        user.FirstName = Console.ReadLine();

        Console.Write("User LastName = ");
        user.LastName = Console.ReadLine();

        Console.Write("User Email = ");
        user.Email = Console.ReadLine();
        
        Console.Write("User Role = ");
        user.UserRole = Enum.Parse<UserRole>(Console.ReadLine());

        Console.Write("User Password = ");
        user.PasswordHash = Console.ReadLine();
        
        user.UpdatedDate = DateTime.Now;

        var isUpdated = await userService.UpdateUserAsync(user);

        if (isUpdated)
            Console.WriteLine("User updated.");
    }

    public async Task DeleteUserMenuAsync()
    {
        Console.Write("User ning Id sini kiriting: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var isDeleted = await userService.DeleteUserAsync(id);

        if (isDeleted)
            Console.WriteLine("User deleted.");
    }
}