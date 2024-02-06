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

