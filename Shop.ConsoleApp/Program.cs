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
MenuServices menuServices = new();


bool Default = true;
while (Default)
{
    menuServices.HomeMenu();

    string? option = Console.ReadLine();
    if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 2))
    {

        switch (optionNumber)
        {
            case (int)Menu1.LogIn:
                {
                    Console.Clear();
                    menuServices.LoginMenu();

                here:
                    string? option1 = Console.ReadLine();
                    int optionNumber1;
                    bool isInt1 = int.TryParse(option1, out optionNumber1);
                    if (isInt1)
                    {
                        if (optionNumber1 >= 0 && optionNumber1 <= 2)
                        {
                            switch (optionNumber1)
                            {
                                case (int)Menu2.GoToRegister:
                                    {
                                        Console.Clear();
                                        menuServices.RegisterMenu();
                                    }
                                    break;
                                case (int)Menu2.LogInAgain:
                                    {
                                        Console.Clear();
                                        menuServices.LoginMenu();
                                    }
                                    break;
                                default:
                                    Console.Clear();
                                    menuServices.HomeMenu();
                                    break;

                            }
                        }
                        goto here;
                    }
                }
                break;
            case (int)Menu1.Register:
                {
                    Console.Clear();
                    menuServices.RegisterMenu();

                    string? option1 = Console.ReadLine();
                    int optionNumber1;
                    bool isInt1 = int.TryParse(option1, out optionNumber1);
                    if (isInt1)
                    {
                        if (optionNumber1 >= 0 && optionNumber1 <= 2)
                        {
                            switch (optionNumber1)
                            {
                                case (int)Menu3.GoToLogIn:
                                    {
                                        Console.Clear();
                                        menuServices.LoginMenu();
                                    }
                                    break;
                                case (int)Menu3.RegisterAgain:
                                    {
                                        Console.Clear();
                                        menuServices.RegisterMenu();
                                    }
                                    break;
                                default:
                                    Console.Clear();
                                    menuServices.HomeMenu();
                                    break;

                            }
                        }
                    }

                }
                break;
        }

    }
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Please choose valid option");
}
//            {
//                Console.Clear();
//            register:

//                try
//                {
//                    await userServices.Create(name, lastname, day, month, year, phone, email, password);

//                    Console.WriteLine("added succsessfully");
//                }
//                catch (Exception ex)
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine(ex.Message);
//                    Console.ResetColor();

//                    Console.Write("[1|Try again]\n" +
//                                  "[0|Back to main menu\n" +
//                                  "\n" +
//                                  "CHOOSE THE OPTION: ");
//                    string? option1 = Console.ReadLine();
//                    int optionNumber1;
//                    bool isInt1 = int.TryParse(option1, out optionNumber1);
//                    if (isInt1)
//                    {
//                        if (optionNumber1 >= 0 && optionNumber1 <= 2)
//                        {
//                            switch (optionNumber1)
//                            {
//                                case (int)Menu3.RegisterAgain:
//                                    {
//                                        goto register;
//                                    }
//                                default:
//                                    goto Menu;
//                            }
//                        }
//                    }
//                }
//                break;
//            }
//        default:
//            {
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("Closing the app...");
//            }
//            break;
//        }
//    }
//    else Console.WriteLine("Please enter valid option");
//}
//else Console.WriteLine("Please enter valid option");




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









