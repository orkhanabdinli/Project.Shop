using Shop.Business.Services;
using Shop.Business.Utilities.Helpers;
using Shop.DataAccess;
using System.Collections.ObjectModel;
UserServices userServices = new();
WalletServices walletServices = new();
ProductServices productServices = new();
BrandServices brandServices = new();
CategoryServices categoryServices = new();
DiscountServices discountServices = new();

Menu:
Console.Clear();
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
string? option = Console.ReadLine();
int optionNumber;
bool isInt = int.TryParse(option, out optionNumber);
if (isInt)
{
    if (optionNumber >= 0 && optionNumber <= 2)
    {
        switch (optionNumber)
        {
            case (int)Menu1.LogIn:
                {
                    Console.Clear();
                login:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("____________________\n" + 
                                      "LOG IN\n" + 
                                      "____________________\n" +
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
                        Console.WriteLine("logged id succsessfully");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n" +
                                         $"{ex.Message}\n" +
                                         "");
                        Console.ResetColor();
                        Console.Write("[1|Try again]\n" +
                                      "[0|Back to main menu\n" +
                                      "\n" +
                                      "CHOOSE THE OPTION: ");
                        string? option1 = Console.ReadLine();
                        int optionNumber1;
                        bool isInt1 = int.TryParse(option1, out optionNumber1);
                        if (isInt1)
                        {
                            if (optionNumber1 >= 0 && optionNumber1 <= 2)
                            {
                                switch (optionNumber1)
                                {
                                    case (int)Menu2.LogInAgain:
                                        {
                                            goto login;
                                        }
                                    default:
                                        goto Menu;
                                }
                            }
                        }
                    }
                    break;
                }
            case (int)Menu1.Register:
                {
                    Console.Clear();
                register:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter name:");
                    Console.ResetColor();
                    string? name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter lastname:");
                    Console.ResetColor();
                    string? lastname = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter birthday");
                    Console.Write("Enter day:");
                    Console.ResetColor();
                    string? day = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter month:");
                    Console.ResetColor();
                    string? month = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter year:");
                    Console.ResetColor();
                    string? year = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter phone number:");
                    Console.ResetColor();
                    string? phone = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter email address:");
                    Console.ResetColor();
                    string? email = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Create password:");
                    Console.ResetColor();
                    string? password = Console.ReadLine();
                    try
                    {
                        await userServices.Create(name, lastname, day, month, year, phone, email, password);
                        Console.WriteLine("added succsessfully");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();

                        Console.Write("[1|Try again]\n" +
                                      "[0|Back to main menu\n" +
                                      "\n" +
                                      "CHOOSE THE OPTION: ");
                        string? option1 = Console.ReadLine();
                        int optionNumber1;
                        bool isInt1 = int.TryParse(option1, out optionNumber1);
                        if (isInt1)
                        {
                            if (optionNumber1 >= 0 && optionNumber1 <= 2)
                            {
                                switch (optionNumber1)
                                {
                                    case (int)Menu3.RegisterAgain:
                                        {
                                            goto register;
                                        }
                                    default:
                                        goto Menu;
                                }
                            }
                        }
                    }
                    break;
                }
            default:
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Closing the app...");
                }
                break;
        }
    }
    else Console.WriteLine("Please enter valid option");
}




//isContinue = false;










//Console.Write("Enter name:");
//string? name = Console.ReadLine();
//Console.Write("Enter description:");
//string? description = Console.ReadLine();
//Console.Write("Enter price:");
//string price = Console.ReadLine();
//Console.Write("Enter amount in stock:");
//int stock = Convert.ToInt32(Console.ReadLine());

//BrandServices brandServices = new BrandServices();
//await brandServices.Create("Apple");

//CategoryServices categoryServices = new CategoryServices();
//await categoryServices.Create("Smartphones");

//ProductServices productServices = new ProductServices();
//await productServices.Create("iPhone 15 ", "", 1500, 20, 1, 1);

//Cart cart = new Cart()
//{
//    Id = 4
//};
//await db.Carts.AddAsync(cart);
//await db.SaveChangesAsync();

//string birthDate = "2000 11 1";
//DateTime birthDate1 = DateTime.Parse(birthDate);
//Console.WriteLine(DateTime.Now);
//Console.WriteLine(birthDate1);

//WalletServices walletServices = new WalletServices();
//await walletServices.Create("Card7", "1234563512246321", "surxan@mail.ru");

//try
//{
//    UserServices userServices = new UserServices();
//    userServices.ChangeEmail("ao@gmail.com", "Orxan0111", "orxan@mail.ru");
//}
//catch (Exception ex)
//{
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine(ex.Message);
//    Console.ResetColor();
//}

//UserServices userServices = new UserServices();
//userServices.ShowAllUsers();

//WalletServices walletServices = new WalletServices();
//walletServices.ShowAllCards("surxan@mail.ru");

//ProductServices productServices = new ProductServices();

//productServices.ShowAllProductsByCategory(1);

//brandServices.ShowAllBrands();

//userServices.ChangePassword("surxan@mail.ru", "surxay1968", "SuRxAy1968");

//categoryServices.ShowAllCategories();

//ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
//Console.WriteLine("The local system has the following {0} time zones", zones.Count);
//foreach (TimeZoneInfo zone in zones)
//    Console.WriteLine(zone.Id);

//DateTime Time = TimeZoneInfo.ConvertTime(DateTime.Now,
//                 TimeZoneInfo.FindSystemTimeZoneById("Azerbaijan Standard Time"));
//Console.WriteLine(Time);







