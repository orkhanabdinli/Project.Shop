using Shop.Business.Interfaces;

namespace Shop.Business.Services;

public class MenuServices
{
    UserServices userServices = new();
    public void HomeMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("   _____ _    _  ____  _____  _____ _____ _   _  _____              _____  _____      _____  _____   ____       _ ______ _____ _______ \r\n  / ____| |  | |/ __ \\|  __ \\|  __ \\_   _| \\ | |/ ____|       /\\   |  __ \\|  __ \\    |  __ \\|  __ \\ / __ \\     | |  ____/ ____|__   __|\r\n | (___ | |__| | |  | | |__) | |__) || | |  \\| | |  __       /  \\  | |__) | |__) |   | |__) | |__) | |  | |    | | |__ | |       | |   \r\n  \\___ \\|  __  | |  | |  ___/|  ___/ | | | . ` | | |_ |     / /\\ \\ |  ___/|  ___/    |  ___/|  _  /| |  | |_   | |  __|| |       | |   \r\n  ____) | |  | | |__| | |    | |    _| |_| |\\  | |__| |    / ____ \\| |    | |        | |    | | \\ \\| |__| | |__| | |___| |____   | |   \r\n |_____/|_|  |_|\\____/|_|    |_|   |_____|_| \\_|\\_____|   /_/    \\_\\_|    |_|        |_|    |_|  \\_\\\\____/ \\____/|______\\_____|  |_|   \r\n                                                                                                                                       \r\n                                                                                                                                       ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("[1|LOG IN]\n" +
                      "[2|REGISTER]\n" +
                      "[0|CLOSE APP]\n" +
                      "\n" +
                      "CHOOSE THE OPTION: ");
        Console.ResetColor();
    }
    public void LoginMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("_______________________________\n" +
                          "\n" +
                          "<<<<<<<<<<< LOG IN >>>>>>>>>>>>\n" +
                          "_______________________________\n" +
                          "\n" +
                          "Please enter your email address: ");
        Console.ResetColor();
        string? email = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" +
                          "Please enter your password: ");
        Console.ResetColor();
        string? password = Console.ReadLine();
        Console.Clear();
        try
        {
            userServices.LogIn(email, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Logged id succsessfully");
            Console.ResetColor();
            bool isAdmin = userServices.IsAdmin(email, password);
            if (isAdmin == true) ;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                             $"{ex.Message}\n" +
                              "___________________________________\n" +
                              "");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Dont have an accaunt?\n" +
                          "[1|Register now]\n" +
                          "[2|Try again]\n" +
                          "[0|Back to main menu]\n" +
                          "\n" +
                          "CHOOSE THE OPTION: ");
            Console.ResetColor();
        }
    }
    public async void RegisterMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<<< REGISTER >>>>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Name: ");
        Console.ResetColor();
        string? name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Lastname: ");
        Console.ResetColor();
        string? lastname = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Enter birthday");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter day:");
        Console.ResetColor();
        string? day = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter month:");
        Console.ResetColor();
        string? month = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter year:");
        Console.ResetColor();
        string? year = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter phone number:");
        Console.ResetColor();
        string? phone = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter email address:");
        Console.ResetColor();
        string? email = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Create password:");
        Console.ResetColor();
        string? password = Console.ReadLine();
        Console.Clear();
        try
        {
            await userServices.Create(name, lastname, day, month, year, phone, email, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Register succeed");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();

            Console.Write("Have an accaunt?\n" +
                          "[1|Log in now]\n" +
                          "[2|Try again]\n" +
                          "[0|Back to main menu\n" +
                          "\n" +
                          "CHOOSE THE OPTION: ");
        }
    }
    public void UserMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("_______________________________\n" +
                          "\n" +
                          "<<<<<<<<<<< LOG IN >>>>>>>>>>>>\n" +
                          "_______________________________\n" +
                          "\n" +
                          "Please enter your email address: ");
        Console.ResetColor();
        string? email = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" +
                          "Please enter your password: ");
        Console.ResetColor();
        string? password = Console.ReadLine();
        Console.Clear();
        try
        {
            bool LoginSucceed = userServices.LogIn(email, password);
            bool IsAdmin = userServices.IsAdmin(email, password);
            if (LoginSucceed == true && IsAdmin == true)
            {

            }

        }
    }
}
