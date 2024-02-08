using Shop.Business.Utilities.Helpers;

namespace Shop.Business.Services;

public class MenuServices
{
    UserServices userServices = new();
    ProductServices productServices = new();
    BrandServices brandServices = new();
    CategoryServices categoryServices = new();
    DiscountServices discountServices = new();

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
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 2))
        {
            switch (optionNumber)
            {
                case (int)Menu1.LogIn:
                    {
                        Console.Clear();
                        LoginMenu();
                    }
                    break;
                case (int)Menu1.Register:
                    {
                        Console.Clear();
                        RegisterMenu();
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
                    }
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            HomeMenu();
        }
    }
    public void LoginMenu()
    {
        MenuServices menuServices = new();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("_______________________________\n" +
                          "\n" +
                          "<<<<<<<<<<< LOG IN >>>>>>>>>>>>\n" +
                          "_______________________________\n" +
                          "\n" +
                          "Email address or phone number: ");
        Console.ResetColor();
        string? emailOrPhone = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" +
                          "Please enter your password: ");
        Console.ResetColor();
        string? password = Console.ReadLine();
        Console.Clear();
        try
        {
            bool LoginSucceed = userServices.LogIn(emailOrPhone, password);
            bool IsAdmin = userServices.IsAdmin(emailOrPhone, password);
            if (LoginSucceed == true && IsAdmin == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "     Logged in succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                AdminMenu(emailOrPhone, password);
            }
            else if (LoginSucceed == true && IsAdmin == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "     Logged in succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                UserMenu(emailOrPhone, password);
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("_______________________________________________\n" +
                              "\n" +
                             $"{ex.Message}\n" +
                              "_______________________________________________\n" +
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
            string? option1 = Console.ReadLine();
            if (int.TryParse(option1, out int optionNumber1) && (optionNumber1 >= 0 && optionNumber1 <= 2))
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
        }
    }
    public void RegisterMenu()
    {
        try
        {
            MenuServices menuServices = new();
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
            userServices.Create(name, lastname, day, month, year, phone, email, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_______________________________\n" +
                                  "\n" +
                              "      Register succeed\n" +
                              "_______________________________");
            Console.ResetColor();
            LoginMenu();
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

            Console.Write("Have an accaunt?\n" +
                          "[1|Log in now]\n" +
                          "[2|Try again]\n" +
                          "[0|Back to main menu\n" +
                          "\n" +
                          "CHOOSE THE OPTION: ");
            string? option1 = Console.ReadLine();
            if (int.TryParse(option1, out int optionNumber1) && (optionNumber1 >= 0 && optionNumber1 <= 2))
            {
                switch (optionNumber1)
                {
                    case (int)Menu3.GoToLogIn:
                        {
                            Console.Clear();
                            LoginMenu();
                        }
                        break;
                    case (int)Menu3.RegisterAgain:
                        {
                            Console.Clear();
                            RegisterMenu();
                        }
                        break;
                    default:
                        Console.Clear();
                        HomeMenu();
                        break;

                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
        }
    }
    public void UserMenu(string emailOrPhone, string password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("__________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<< USER MENU >>>>>>>>>>>>\n" +
                      "__________________________________\n" +
                      "\n" +
                      "[1|Producs]\n" +
                      "[2|Cart]\n" +
                      "[3|Wallet]\n" +
                      "[4|Edit profile]\n" +
                      "[0|Log out]\n" +
                      "\n" +
                      "CHOOSE THE OPTION: ");
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 6))
        {
            switch (optionNumber)
            {
                case (int)Adminmenu.Products:
                    {
                        Console.Clear();
                        ProductsMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Brands:
                    {
                        Console.Clear();
                        BrandsMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Category:
                    {
                        CategoriesMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Discounts:
                    {
                        DiscountsMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Users:
                    {
                        EditUsersMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.EditProfile:
                    {
                        EditProfile(emailOrPhone, password);
                    }
                    break;
                default:
                    {
                        Console.Clear();
                        emailOrPhone = null;
                        password = null;
                        HomeMenu();
                        break;
                    }
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            AdminMenu(emailOrPhone, password);
        }
    }
    public void AdminMenu(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("__________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<< ADMIN MENU >>>>>>>>>>>\n" +
                      "__________________________________\n" +
                      "\n" +
                      "[1|Producs]\n" +
                      "[2|Brands]\n" +
                      "[3|Categories]\n" +
                      "[4|Discounts]\n" +
                      "[5|Users]\n" +
                      "[6|Edit profile]\n" +
                      "[0|Log out]\n" +
                      "\n" +
                      "CHOOSE THE OPTION: ");
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 6))
        {
            switch (optionNumber)
            {
                case (int)Adminmenu.Products:
                    {
                        Console.Clear();
                        ProductsMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Brands:
                    {
                        Console.Clear();
                        BrandsMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Category:
                    {
                        Console.Clear();
                        CategoriesMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Discounts:
                    {
                        Console.Clear();
                        DiscountsMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.Users:
                    {
                        Console.Clear();
                        EditUsersMenu(emailOrPhone, password);
                    }
                    break;
                case (int)Adminmenu.EditProfile:
                    {
                        Console.Clear();
                        EditProfile(emailOrPhone, password);
                    }
                    break;
                default:
                    {
                        Console.Clear();
                        emailOrPhone = null;
                        password = null;
                        HomeMenu();
                        break;
                    }
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            AdminMenu(emailOrPhone, password);
        }
    }


    //----------        -------------------------------------------------------------------------------------------------------------
    //----------PRODUCTS-------------------------------------------------------------------------------------------------------------
    //----------        -------------------------------------------------------------------------------------------------------------
    public void ProductsMenu(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<< PRODUCTS MENU >>>>>>>>>>\n" +
                      "___________________________________\n" +
                          "\n" +
                          " [1|Add]\n" +
                          " [2|Activate]\n" +
                          " [3|Deactivate]\n" +
                          " [4|Apply discount]\n" +
                          " [5|Change name]\n" +
                          " [6|Change description]\n" +
                          " [7|Change price]\n" +
                          " [8|Change stock]\n" +
                          " [9|Change brand]\n" +
                          "[10|Change category]\n" +
                          "[11|Show all products]\n" +
                          " [0]Back]\n" +
                          "\n" +
                          "CHOOSE THE OPTION: ");
        Console.ResetColor();
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 11))
        {
            Console.Clear();
            switch (optionNumber)
            {
                case (int)Productsmenu.Add:
                    {
                        ProductAdd(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.Activate:
                    {
                        ActivateProduct(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.Deactivate:
                    {
                        DeactivateProduct(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ApplyDiscount:
                    {
                        ApplyDiscount(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ChangeName:
                    {
                        ChangeName(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ChangeDescription:
                    {
                        ChangeDescription(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ChangePrice:
                    {
                        ChangePrice(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ChangeStock:
                    {
                        ChangeStock(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ChangeBrand:
                    {
                        ChangeBrand(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ChangeCategory:
                    {
                        ChangeCategory(emailOrPhone, password);
                    }
                    break;
                case (int)Productsmenu.ShowAllProducts:
                    {
                        ShowAllProducts(emailOrPhone, password);
                    }
                    break;
                default:
                    AdminMenu(emailOrPhone, password);
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
    }
    public void ProductAdd(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< ADD PRODUCT >>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (brandServices.IsBrandsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No brands available");
            ProductsMenu(emailOrPhone, password);
        }
        if (categoryServices.IsCategoriesExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No categories available");
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Name: ");
                Console.ResetColor();
                string? name = Console.ReadLine();
                if (name == "0") ProductsMenu(emailOrPhone, password);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Description: ");
                Console.ResetColor();
                string? description = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Price: ");
                Console.ResetColor();
                decimal? price = Convert.ToDecimal(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Stock: ");
                Console.ResetColor();
                string? stock = Console.ReadLine();
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Brand ID: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Category ID: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                productServices.Create(name, description, price, stock, brandId, categoryId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "   Product added succsessfully\n" +
                                  "__________________________________");
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("________________________________________________\n" +
                                  "\n" +
                                 $"{ex.Message}\n" +
                                  "________________________________________________\n" +
                                  "");
                Console.ResetColor();
                ProductAdd(emailOrPhone, password);
            }
        }
    }
    public void ActivateProduct(string? emailOrPhone, string? password)
    {
        if (productServices.IsAnyDeactiveProduct() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No deactive products");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< ACTIVATE PRODUCT >>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< DEACTIVE PRODUCTS >>>>>>>\n");
                productServices.ShowDeactiveProducts();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose product ID: ");
                Console.ResetColor();
                int? prodId = Convert.ToInt32(Console.ReadLine());
                if (prodId == 0) ProductsMenu(emailOrPhone, password);
                productServices.Activate(prodId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Activated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"   {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                ActivateProduct(emailOrPhone, password);
            }
        }
    }
    public void DeactivateProduct(string? emailOrPhone, string? password)
    {
        if (productServices.IsAnyActiveProduct() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No active products");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<< Deactivate Product >>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< Active Products >>>>>>>>>\n");
                productServices.ShowActiveProducts();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose product ID: ");
                Console.ResetColor();
                int? prodId = Convert.ToInt32(Console.ReadLine());
                if (prodId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                productServices.Deactivate(prodId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "    Deactivated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                DeactivateProduct(emailOrPhone, password);
            }
        }
    }
    public void ApplyDiscount(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<< APPLYING DISCOUNT >>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (brandServices.IsAnyActiveBrand() == false || categoryServices.IsAnyActiveCategory() == false || productServices.IsAnyActiveProduct() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        if (discountServices.IsAnyActiveDiscount() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No discounts available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");

                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                if (categoryId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ShowProductsByBrandAndCategory(brandId, categoryId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose product: ");
                Console.ResetColor();
                int? productId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                discountServices.ShowActiveDiscounts();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose discount: ");
                Console.ResetColor();
                int? discountId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                discountServices.ApplyDiscounToProduct(productId, discountId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ApplyDiscount(emailOrPhone, password);
            }
        }
    }
    public void ChangeName(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< CHANGE NAME >>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");

                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                if (categoryId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ShowProductsByBrandAndCategory(brandId, categoryId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose product: ");
                Console.ResetColor();
                int? productId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new name: ");
                Console.ResetColor();
                string? newName = Console.ReadLine();
                Console.Clear();
                productServices.ChangeName(productId, newName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeName(emailOrPhone, password);
            }
        }
    }
    public void ChangeDescription(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<< CHANGE DESCRIPTION >>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");

                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                if (categoryId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ShowProductsByBrandAndCategory(brandId, categoryId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose product: ");
                Console.ResetColor();
                int? productId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new description: ");
                Console.ResetColor();
                string? newName = Console.ReadLine();
                Console.Clear();
                productServices.ChangeDescription(productId, newName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeDescription(emailOrPhone, password);
            }
        }
    }
    public void ChangePrice(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< CHANGE PRICE >>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");

                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                if (categoryId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ShowProductsByBrandAndCategory(brandId, categoryId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose product: ");
                Console.ResetColor();
                int? productId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new price: ");
                Console.ResetColor();
                decimal? newPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();
                productServices.ChangePrice(productId, newPrice);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangePrice(emailOrPhone, password);
            }
        }
    }
    public void ChangeStock(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< CHANGE STOCK >>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");

                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                if (categoryId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ShowProductsByBrandAndCategory(brandId, categoryId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose product: ");
                Console.ResetColor();
                int? productId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new amount in stock: ");
                Console.ResetColor();
                int? newStock = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ChangeStock(productId, newStock);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeStock(emailOrPhone, password);
            }
        }
    }
    public void ChangeBrand(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< CHANGE BRAND >>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");

                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                if (categoryId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ShowProductsByBrandAndCategory(brandId, categoryId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose product: ");
                Console.ResetColor();
                int? productId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new brand ID: ");
                Console.ResetColor();
                int? newBrandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ChangeBrand(productId, newBrandId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeBrand(emailOrPhone, password);
            }
        }
    }
    public void ChangeCategory(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<< CHANGE CATEGORY >>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");

                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category: ");
                Console.ResetColor();
                int? categoryId = Convert.ToInt32(Console.ReadLine());
                if (categoryId == 0) ProductsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ShowProductsByBrandAndCategory(brandId, categoryId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose product: ");
                Console.ResetColor();
                int? productId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new category ID: ");
                Console.ResetColor();
                int? newCategoryId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                productServices.ChangeCategory(productId, newCategoryId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                ProductsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeCategory(emailOrPhone, password);
            }
        }
    }
    public void ShowAllProducts(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<< ALL PRODUCTS >>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        else
        {
            productServices.ShowAllProducts();
            ProductsMenu(emailOrPhone, password);
        }
    }


    //----------      ----------------------------------------------------------------------------------------------------------------
    //----------BRANDS----------------------------------------------------------------------------------------------------------------
    //----------      ----------------------------------------------------------------------------------------------------------------
    public void BrandsMenu(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("___________________________________\n" +
                         "\n" +
                         "<<<<<<<<<<< BRANDS MENU >>>>>>>>>>>\n" +
                         "___________________________________\n" +
                         "\n" +
                         "[1|Add]\n" +
                         "[2|Activate]\n" +
                         "[3|Deactivate]\n" +
                         "[4|Change name]\n" +
                         "[5|Show all brands]\n" +
                         "[0]Back]\n" +
                         "\n" +
                          "CHOOSE THE OPTION: ");
        Console.ResetColor();
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 5))
        {
            Console.Clear();
            switch (optionNumber)
            {
                case (int)Brandsmenu.Add:
                    {
                        BrandAdd(emailOrPhone, password);
                    }
                    break;
                case (int)Brandsmenu.Activate:
                    {
                        ActivateBrand(emailOrPhone, password);
                    }
                    break;
                case (int)Brandsmenu.Deactivate:
                    {
                        DeactivateBrand(emailOrPhone, password);
                    }
                    break;
                case (int)Brandsmenu.ChangeName:
                    {
                        ChangeBrandName(emailOrPhone, password);
                    }
                    break;
                case (int)Brandsmenu.ShowAllBrands:
                    {
                        ShowAllBrands(emailOrPhone, password);
                    }
                    break;
                default:
                    AdminMenu(emailOrPhone, password);
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            BrandsMenu(emailOrPhone, password);
        }
    }
    public async void BrandAdd(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<<< ADD BRAND >>>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");

        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Name: ");
            Console.ResetColor();
            string? name = Console.ReadLine();
            if (name == "0") BrandsMenu(emailOrPhone, password);
            await brandServices.Create(name);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                              "     Brand added succsessfully\n" +
                              "___________________________________");
            BrandsMenu(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________\n" +
                              "\n" +
                             $"{ex.Message}\n" +
                              "________________________________________________\n" +
                              "");
            Console.ResetColor();
            BrandAdd(emailOrPhone, password);
        }
    }
    public async void ActivateBrand(string? emailOrPhone, string? password)
    {
        if (brandServices.IsAnyDeactiveBrand() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No deactive brands");
            Console.ResetColor();
            BrandsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< ACTIVATE BRAND >>>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< DEACTIVE BRANDS >>>>>>>\n");
                brandServices.ShowDeactiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose brand ID: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                if (brandId == 0) BrandsMenu(emailOrPhone, password);
                brandServices.ActivateBrand(brandId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Activated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                BrandsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                ActivateBrand(emailOrPhone, password);
            }
        }
    }
    public async void DeactivateBrand(string? emailOrPhone, string? password)
    {
        if (brandServices.IsAnyActiveBrand() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No active brands");
            Console.ResetColor();
            BrandsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< DEACTIVATE BRAND >>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<<<< ACTIVE BRANDS >>>>>>>>>\n");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose brand ID: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                if (brandId == 0) BrandsMenu(emailOrPhone, password);
                brandServices.DeactivateBrand(brandId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "    Deactivated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                BrandsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                DeactivateBrand(emailOrPhone, password);
            }
        }
    }
    public void ChangeBrandName(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< CHANGE NAME >>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (brandServices.IsBrandsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No brands available");
            Console.ResetColor();
            BrandsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<<<< BRANDS >>>>>>>>>>>>>>");
                brandServices.ShowActiveBrands();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose brand: ");
                Console.ResetColor();
                int? brandId = Convert.ToInt32(Console.ReadLine());
                if (brandId == 0) BrandsMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new name: ");
                Console.ResetColor();
                string? newName = Console.ReadLine();
                Console.Clear();
                brandServices.ChangeName(brandId, newName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                BrandsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeBrandName(emailOrPhone, password);
            }
        }
    }
    public void ShowAllBrands(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< ALL BRANDS >>>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (brandServices.IsBrandsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No brands available");
            Console.ResetColor();
            BrandsMenu(emailOrPhone, password);
        }
        else
        {
            brandServices.ShowAllBrands();
            ProductsMenu(emailOrPhone, password);
        }
    }


    //-----------          -------------------------------------------------------------------------------------------------------------
    //-----------CATEGORIES-------------------------------------------------------------------------------------------------------------
    //-----------          -------------------------------------------------------------------------------------------------------------
    public void CategoriesMenu(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("___________________________________\n" +
                         "\n" +
                         "<<<<<<<<<< CATEGORIES MENU >>>>>>>>>\n" +
                         "___________________________________\n" +
                         "\n" +
                         "[1|Add]\n" +
                         "[2|Activate]\n" +
                         "[3|Deactivate]\n" +
                         "[4|Change name]\n" +
                         "[5|Show all categories]\n" +
                         "[0]Back]\n" +
                         "\n" +
                          "CHOOSE THE OPTION: ");
        Console.ResetColor();
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 5))
        {
            Console.Clear();
            switch (optionNumber)
            {
                case (int)Categoriesmenu.Add:
                    {
                        CategoryAdd(emailOrPhone, password);
                    }
                    break;
                case (int)Categoriesmenu.Activate:
                    {
                        ActivateCategory(emailOrPhone, password);
                    }
                    break;
                case (int)Categoriesmenu.Deactivate:
                    {
                        DeactivateCategory(emailOrPhone, password);
                    }
                    break;
                case (int)Categoriesmenu.ChangeName:
                    {
                        ChangeCategoryName(emailOrPhone, password);
                    }
                    break;
                case (int)Categoriesmenu.ShowAllCategories:
                    {
                        ShowAllCategories(emailOrPhone, password);
                    }
                    break;
                default:
                    AdminMenu(emailOrPhone, password);
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            CategoriesMenu(emailOrPhone, password);
        }
    }
    public void CategoryAdd(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<< ADD CATEGORY >>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");

        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Name: ");
            Console.ResetColor();
            string? name = Console.ReadLine();
            if (name == "0") CategoriesMenu(emailOrPhone, password);
            categoryServices.Create(name);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("__________________________________\n" +
                              "\n" +
                              "  Category added succsessfully\n" +
                              "__________________________________");
            CategoriesMenu(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________\n" +
                              "\n" +
                             $"{ex.Message}\n" +
                              "________________________________________________\n" +
                              "");
            Console.ResetColor();
            CategoryAdd(emailOrPhone, password);
        }
    }
    public async void ActivateCategory(string? emailOrPhone, string? password)
    {
        if (categoryServices.IsAnyDeactiveCategory() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No deactive categories");
            Console.ResetColor();
            CategoriesMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<< ACTIVATE CATEGORY >>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<< DEACTIVE CATEGORIES >>>>>>>\n");
                categoryServices.ShowDeactiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose category ID: ");
                Console.ResetColor();
                int? catId = Convert.ToInt32(Console.ReadLine());
                if (catId == 0) CategoriesMenu(emailOrPhone, password);
                categoryServices.ActivateCategory(catId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Activated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                CategoriesMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                ActivateCategory(emailOrPhone, password);
            }
        }
    }
    public async void DeactivateCategory(string? emailOrPhone, string? password)
    {
        if (categoryServices.IsAnyActiveCategory() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No active categories");
            Console.ResetColor();
            CategoriesMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<< DEACTIVATE CATEGORY >>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< ACTIVE CATEGORIES >>>>>>>\n");
                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose category ID: ");
                Console.ResetColor();
                int? catId = Convert.ToInt32(Console.ReadLine());
                if (catId == 0) CategoriesMenu(emailOrPhone, password);
                categoryServices.DeactivateCategory(catId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "    Deactivated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                CategoriesMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                DeactivateCategory(emailOrPhone, password);
            }
        }
    }
    public void ChangeCategoryName(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< CHANGE NAME >>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (categoryServices.IsCategoriesExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No categories available");
            Console.ResetColor();
            CategoriesMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< CATEGORIES >>>>>>>>>>>>");
                categoryServices.ShowActiveCategories();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose category ID: ");
                Console.ResetColor();
                int? catId = Convert.ToInt32(Console.ReadLine());
                if (catId == 0) CategoriesMenu(emailOrPhone, password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new name: ");
                Console.ResetColor();
                string? newName = Console.ReadLine();
                Console.Clear();
                categoryServices.ChangeName(catId, newName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                CategoriesMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeCategoryName(emailOrPhone, password);
            }
        }
    }
    public void ShowAllCategories(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<< ALL CATEGORIES >>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (categoryServices.IsCategoriesExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No categories available");
            Console.ResetColor();
            CategoriesMenu(emailOrPhone, password);
        }
        else
        {
            categoryServices.ShowAllCategories();
            CategoriesMenu(emailOrPhone, password);
        }
    }


    //-----------         --------------------------------------------------------------------------------------------------------------
    //-----------DISCOUNTS--------------------------------------------------------------------------------------------------------------
    //-----------         --------------------------------------------------------------------------------------------------------------
    public void DiscountsMenu(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("__________________________________\n" +
                         "\n" +
                         "<<<<<<<<<< DISCOUNTS MENU >>>>>>>>>\n" +
                         "___________________________________\n" +
                         "\n" +
                         "[1|Add]\n" +
                         "[2|Activate]\n" +
                         "[3|Deactivate]\n" +
                         "[4|Change name]\n" +
                         "[5|Change percentage]\n" +
                         "[6|Show all discounts]\n" +
                         "[0]Back]\n" +
                         "\n" +
                          "CHOOSE THE OPTION: ");
        Console.ResetColor();
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 6))
        {
            Console.Clear();
            switch (optionNumber)
            {
                case (int)Discountsmenu.Add:
                    {
                        DiscountAdd(emailOrPhone, password);
                    }
                    break;
                case (int)Discountsmenu.Activate:
                    {
                        ActivateDiscount(emailOrPhone, password);
                    }
                    break;
                case (int)Discountsmenu.Deactivate:
                    {
                        DeactivateDiscount(emailOrPhone, password);
                    }
                    break;
                case (int)Discountsmenu.ChangeName:
                    {
                        ChangeDiscountName(emailOrPhone, password);
                    }
                    break;
                case (int)Discountsmenu.ChangePercentage:
                    {
                        ChangeDiscountPercent(emailOrPhone, password);
                    }
                    break;
                case (int)Discountsmenu.ShowAllDiscounts:
                    {
                        ShowAllDiscounts(emailOrPhone, password);
                    }
                    break;
                default:
                    AdminMenu(emailOrPhone, password);
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            DiscountsMenu(emailOrPhone, password);
        }
    }
    public void DiscountAdd(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<< ADD DISCOUNT >>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Name: ");
            Console.ResetColor();
            string? name = Console.ReadLine();
            if (name == "0") DiscountsMenu(emailOrPhone, password);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Percentage: ");
            Console.ResetColor();
            int? percent = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Duration in days: ");
            Console.ResetColor();
            int? duration = Convert.ToInt32(Console.ReadLine());
            discountServices.Create(name, percent, duration);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("__________________________________\n" +
                              "\n" +
                              "   Discount added succsessfully\n" +
                              "__________________________________");
            DiscountsMenu(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________\n" +
                              "\n" +
                             $"{ex.Message}\n" +
                              "________________________________________________\n" +
                              "");
            Console.ResetColor();
            DiscountAdd(emailOrPhone, password);
        }
    }
    public void ActivateDiscount(string? emailOrPhone, string? password)
    {
        if (discountServices.IsAnyDeactiveBrand() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No deactive discounts");
            Console.ResetColor();
            DiscountsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<< ACTIVATE DISCOUNT >>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<< DEACTIVE DISCOUNTs >>>>>>>\n");
                discountServices.ShowDeactiveDiscounts();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose discount ID: ");
                Console.ResetColor();
                int? disId = Convert.ToInt32(Console.ReadLine());
                if (disId == 0) DiscountsMenu(emailOrPhone, password);
                discountServices.ActivateDiscount(disId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Activated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                DiscountsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                ActivateDiscount(emailOrPhone, password);
            }
        }
    }
    public void DeactivateDiscount(string? emailOrPhone, string? password)
    {
        if (discountServices.IsAnyActiveDiscount() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No active discounts");
            Console.ResetColor();
            DiscountsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<< DEACTIVATE DISCOUNT >>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< ACTIVE DISCOUNTS >>>>>>>>\n");
                discountServices.ShowActiveDiscounts();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose discount ID: ");
                Console.ResetColor();
                int? disId = Convert.ToInt32(Console.ReadLine());
                if (disId == 0) CategoriesMenu(emailOrPhone, password);
                discountServices.DeactivateDiscount(disId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "    Deactivated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                DiscountsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                DeactivateDiscount(emailOrPhone, password);
            }
        }
    }
    public void ChangeDiscountName(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< CHANGE NAME >>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (discountServices.IsAnyActiveDiscount() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No discounts available");
            Console.ResetColor();
            DiscountsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< DISCOUNTS >>>>>>>>>>>>");
                discountServices.ShowActiveDiscounts();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose discount ID: ");
                Console.ResetColor();
                int? disId = Convert.ToInt32(Console.ReadLine());
                if (disId == 0) CategoriesMenu(emailOrPhone, password);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new name: ");
                Console.ResetColor();
                string? newName = Console.ReadLine();
                Console.Clear();
                discountServices.ChangeName(disId, newName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                DiscountsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeDiscountName(emailOrPhone, password);
            }
        }
    }
    public void ChangeDiscountPercent(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<< CHANGE PERCENTAGE >>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (discountServices.IsDiscountExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No discounts available");
            Console.ResetColor();
            DiscountsMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                  "<<<<<<<<<<< DISCOUNTS >>>>>>>>>>>>");
                discountServices.ShowActiveDiscounts();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose discount ID: ");
                Console.ResetColor();
                int? disId = Convert.ToInt32(Console.ReadLine());
                if (disId == 0)
                {
                    Console.Clear();
                    DiscountsMenu(emailOrPhone, password);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter new percent: ");
                Console.ResetColor();
                int? newPercent = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                discountServices.ChangePercentage(disId, newPercent);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Applied succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                DiscountsMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"  {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");
                Console.ResetColor();
                ChangeDiscountPercent(emailOrPhone, password);
            }
        }
    }
    public void ShowAllDiscounts(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<< ALL DISCOUNTS >>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        if (discountServices.IsDiscountExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No discounts available");
            Console.ResetColor();
            DiscountsMenu(emailOrPhone, password);
        }
        else
        {
            discountServices.ShowAllDiscounts();
            CategoriesMenu(emailOrPhone, password);
        }
    }


    //-----------         --------------------------------------------------------------------------------------------------------------
    //-----------EDIT USER--------------------------------------------------------------------------------------------------------------
    //-----------         --------------------------------------------------------------------------------------------------------------
    public async void EditUsersMenu(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("__________________________________\n" +
                         "\n" +
                         "<<<<<<<<< EDIT USERS MENU >>>>>>>>>\n" +
                         "___________________________________\n" +
                         "\n" +
                         "[1|Activate]\n" +
                         "[2|Deactivate]\n" +
                         "[3|Make admin]\n" +
                         "[4|Disable admin]\n" +
                         "[5|Show all users]\n" +
                         "[0]Back]\n" +
                         "\n" +
                          "CHOOSE THE OPTION: ");
        Console.ResetColor();
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 5))
        {
            Console.Clear();
            switch (optionNumber)
            {
                case (int)EditUsersmenu.Activate:
                    {
                        ActivateUser(emailOrPhone, password);
                    }
                    break;
                case (int)EditUsersmenu.Deactivate:
                    {
                        DeactivateUser(emailOrPhone, password);
                    }
                    break;
                case (int)EditUsersmenu.MakeAdmin:
                    {
                        MakeAdmin(emailOrPhone, password);
                    }
                    break;
                case (int)EditUsersmenu.DisableAdmin:
                    {
                        DisableAdmin(emailOrPhone, password);
                    }
                    break;
                case (int)EditUsersmenu.ShowAllUsers:
                    {
                        ShowAllUsers(emailOrPhone, password);
                    }
                    break;
                default:
                    AdminMenu(emailOrPhone, password);
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            EditUsersMenu(emailOrPhone, password);
        }
    }
    public void ActivateUser(string? emailOrPhone, string? password)
    {
        if (userServices.IsAnyDeactiveUser() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No deactive users");
            Console.ResetColor();
            EditUsersMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<<< ACTIVATE USER >>>>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<<< DEACTIVE USERS >>>>>>>>>\n");
                userServices.ShowDeactiveUsers();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose user ID: ");
                Console.ResetColor();
                int? userId = Convert.ToInt32(Console.ReadLine());
                if (userId == 0)
                {
                    Console.Clear();
                    EditUsersMenu(emailOrPhone, password);
                }
                userServices.ActivateUser(userId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "      Activated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                EditUsersMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                ActivateUser(emailOrPhone, password);
            }
        }
    }
    public void DeactivateUser(string? emailOrPhone, string? password)
    {
        if (userServices.IsAnyActiveUser() == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No active users");
            Console.ResetColor();
            EditUsersMenu(emailOrPhone, password);
        }
        else
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< DEACTIVATE USER >>>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<<<< ACTIVE USERS >>>>>>>>>>\n");
                userServices.ShowActiveUsers();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" +
                              "Choose user ID: ");
                Console.ResetColor();
                int? userId = Convert.ToInt32(Console.ReadLine());
                if (userId == 0)
                {
                    Console.Clear();
                    EditUsersMenu(emailOrPhone, password);
                }
                userServices.DeactivateUser(userId);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("__________________________________\n" +
                                  "\n" +
                                  "    Deactivated succsessfully\n" +
                                  "__________________________________");
                Console.ResetColor();
                EditUsersMenu(emailOrPhone, password);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________\n" +
                                  "\n" +
                                 $"     {ex.Message}\n" +
                                  "___________________________________\n" +
                                  "");

                DeactivateUser(emailOrPhone, password);
            }
        }
    }
    public void MakeAdmin(string? emailOrPhone, string? password)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<<<< MAKE ADMIN >>>>>>>>>>>\n" +
                          "___________________________________\n");

            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<< NOT ADMIN USERS >>>>>>>>\n");
            userServices.ShowNotAdminUsers();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n" +
                          "Choose user ID: ");
            Console.ResetColor();
            int? userId = Convert.ToInt32(Console.ReadLine());
            if (userId == 0)
            {
                Console.Clear();
                EditUsersMenu(emailOrPhone, password);
            }
            userServices.MakeAdmin(userId);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("__________________________________\n" +
                              "\n" +
                              "     Admin set succsessfully\n" +
                              "__________________________________");
            Console.ResetColor();
            EditUsersMenu(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                             $"     {ex.Message}\n" +
                              "___________________________________\n" +
                              "");

            MakeAdmin(emailOrPhone, password);
        }
    }
    public void DisableAdmin(string? emailOrPhone, string? password)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<<< DISABLE ADMIN >>>>>>>>>\n" +
                          "___________________________________\n");

            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<<<< ADMIN USERS >>>>>>>>>>\n");
            userServices.ShowAdminUsers();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n" +
                          "Choose user ID: ");
            Console.ResetColor();
            int? userId = Convert.ToInt32(Console.ReadLine());
            if (userId == 0)
            {
                Console.Clear();
                EditUsersMenu(emailOrPhone, password);
            }
            userServices.DisableAdmin(userId);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("__________________________________\n" +
                              "\n" +
                              " Admin disabled succsessfully\n" +
                              "__________________________________");
            Console.ResetColor();
            EditUsersMenu(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                             $"     {ex.Message}\n" +
                              "___________________________________\n" +
                              "");

            DisableAdmin(emailOrPhone, password);
        }
    }
    public void ShowAllUsers(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<<< ALL Users >>>>>>>>>>>\n" +
                      "___________________________________\n" +
                      "\n");

        discountServices.ShowAllDiscounts();
        EditUsersMenu(emailOrPhone, password);
    }

    //-----------            -----------------------------------------------------------------------------------------------------------
    //-----------EDIT PROFILE-----------------------------------------------------------------------------------------------------------
    //-----------            -----------------------------------------------------------------------------------------------------------
    public async void EditProfile(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("__________________________________\n" +
                         "\n" +
                         "<<<<<<<<<<< EDIT PROFILE >>>>>>>>>>\n" +
                         "___________________________________\n" +
                         "\n" +
                         "[1|Change password]\n" +
                         "[2|Change email]\n" +
                         "[3|Change phone]\n" +
                         "[4|Change name and lastname]\n" +
                         "[5|Change birth date]\n" +
                         "[0]Back]\n" +
                         "\n" +
                          "CHOOSE THE OPTION: ");
        Console.ResetColor();
        string? option = Console.ReadLine();
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 5))
        {
            Console.Clear();
            switch (optionNumber)
            {
                case (int)EditProfilesmenu.ChangePassword:
                    {
                        ChangePassword(emailOrPhone, password);
                    }
                    break;
                case (int)EditProfilesmenu.ChangeEmail:
                    {
                        ChangeEmail(emailOrPhone, password);
                    }
                    break;
                case (int)EditProfilesmenu.ChangePhone:
                    {
                        ChangePhone(emailOrPhone, password);
                    }
                    break;
                case (int)EditProfilesmenu.ChangeNameAndLastname:
                    {
                        ChangeNameAndLastname(emailOrPhone, password);
                    }
                    break;
                case (int)EditProfilesmenu.ChangeBirthDate:
                    {
                        ChangeBirthDate(emailOrPhone, password);
                    }
                    break;
                default:
                    AdminMenu(emailOrPhone, password);
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
            Console.ResetColor();
            EditUsersMenu(emailOrPhone, password);
        }
    }
    public void ChangePassword(string? emailOrPhone, string? password)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<< CHANGE PASSWORD >>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n");
            Console.Write("Old password: ");
            Console.ResetColor();
            string? oldPassword = Console.ReadLine();
            if (oldPassword == "0")
            {
                Console.Clear();
                EditProfile(emailOrPhone, password);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("New password: ");
            Console.ResetColor();
            string? newPassword = Console.ReadLine();
            userServices.ChangePassword(emailOrPhone, oldPassword, newPassword);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("____________________________________\n" +
                              "\n" +
                              " Password changed succsessfully\n" +
                              "____________________________________");
            EditProfile(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                             $"  {ex.Message}\n" +
                              "___________________________________\n" +
                              "");
            Console.ResetColor();
            ChangePassword(emailOrPhone, password);
        }
    }
    public void ChangeEmail(string? emailOrPhone, string? password)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<<< CHANGE EMAIL >>>>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n");
            Console.Write("Password: ");
            Console.ResetColor();
            string? _password = Console.ReadLine();
            if (_password == "0")
            {
                Console.Clear();
                EditProfile(emailOrPhone, password);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("New email: ");
            Console.ResetColor();
            string? newEmail = Console.ReadLine();
            userServices.ChangeEmail(emailOrPhone, _password, newEmail);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("____________________________________\n" +
                              "\n" +
                              "   Email changed succsessfully\n" +
                              "____________________________________");
            EditProfile(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                             $"  {ex.Message}\n" +
                              "___________________________________\n" +
                              "");
            Console.ResetColor();
            ChangeEmail(emailOrPhone, password);
        }
    }
    public void ChangePhone(string? emailOrPhone, string? password)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<<< CHANGE PHONE >>>>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n");
            Console.Write("Password: ");
            Console.ResetColor();
            string? _password = Console.ReadLine();
            if (_password == "0")
            {
                Console.Clear();
                EditProfile(emailOrPhone, password);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("New phone: ");
            Console.ResetColor();
            string? newPhone = Console.ReadLine();
            userServices.ChangePhone(emailOrPhone, _password, newPhone);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("____________________________________\n" +
                              "\n" +
                              "   Phone changed succsessfully\n" +
                              "____________________________________");
            EditProfile(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                             $"  {ex.Message}\n" +
                              "___________________________________\n" +
                              "");
            Console.ResetColor();
            ChangePhone(emailOrPhone, password);
        }
    }
    public void ChangeNameAndLastname(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<< CHANGE NAME & LASTNAME >>>>>\n" +
                      "___________________________________\n" +
                      "\n");
        Console.Write("New name: ");
        Console.ResetColor();
        string? newName = Console.ReadLine();
        if (newName == "0")
        {
            Console.Clear();
            EditProfile(emailOrPhone, password);
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("New lastname: ");
        Console.ResetColor();
        string? newLastname = Console.ReadLine();
        userServices.ChangeNameAndLastname(emailOrPhone, newName, newLastname);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("____________________________________\n" +
                          "\n" +
                          "     Changed succsessfully\n" +
                          "____________________________________");
        EditProfile(emailOrPhone, password);
    }
    public void ChangeBirthDate(string? emailOrPhone, string? password)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<< CHANGE BIRTHDATE >>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter new birthday");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Day:");
            Console.ResetColor();
            string? day = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Month:");
            Console.ResetColor();
            string? month = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Year:");
            Console.ResetColor();
            string? year = Console.ReadLine();
            userServices.ChangeBirthDate(emailOrPhone, day, month, year);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("____________________________________\n" +
                              "\n" +
                              "     Changed succsessfully\n" +
                              "____________________________________");
            EditProfile(emailOrPhone, password);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___________________________________\n" +
                              "\n" +
                             $"  {ex.Message}\n" +
                              "___________________________________\n" +
                              "");
            Console.ResetColor();
            ChangeBirthDate(emailOrPhone, password);
        }
    }
}
































