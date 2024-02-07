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
                }
                break;
            case (int)Menu1.Register:
                {
                    Console.Clear();
                    menuServices.RegisterMenu();
                }
                break;
            default:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("__________________________________\n" +
                                      "\n" +
                                      "         CLOSING THE APP...\n" +
                                      "__________________________________\n");
                    Console.ResetColor();
                    Default = false;
                }
                break;
        }
    }
    else
    {
        if (Default == true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
        }
    }
}

