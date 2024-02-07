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
                AdminMenu(emailOrPhone, password);
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
    public async void RegisterMenu()
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose valid option");
        }
    }
    public void UserMenu(string emailOrPhone, string password)
    {
        Console.WriteLine("Hello");
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
                        CategoriesMenu();
                    }
                    break;
                case (int)Adminmenu.Discounts:
                    {
                        DiscountsMenu();
                    }
                    break;
                case (int)Adminmenu.Users:
                    {
                        UsersMenu();
                    }
                    break;
                case (int)Adminmenu.EditProfile:
                    {
                        EditProfile(emailOrPhone);
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
    public async void ProductsMenu(string? emailOrPhone, string? password)
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
    public async void ProductAdd(string? emailOrPhone, string? password)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                      "<<<<<<<<<<<< Add Product >>>>>>>>>>\n" +
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
                await productServices.Create(name, description, price, stock, brandId, categoryId);
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
                              "<<<<<<<<< Activate Product >>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< Deactive Products >>>>>>>\n");
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
                                 $"     {ex.Message}\n" +
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
        if (productServices.IsProductsExist() == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products available");
            Console.ResetColor();
            ProductsMenu(emailOrPhone, password);
        }
        if (discountServices.IsDiscountExist() == false)
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
    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------
    public async void BrandsMenu(string? emailOrPhone, string? password)
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
        if (int.TryParse(option, out int optionNumber) && (optionNumber >= 0 && optionNumber <= 11))
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
            Console.WriteLine("__________________________________\n" +
                              "\n" +
                              "     Brand added succsessfully\n" +
                              "__________________________________");
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
    public void ActivateBrand(string? emailOrPhone, string? password)
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
    public void DeactivateBrand(string? emailOrPhone, string? password)
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
                              "<<<<<<<<< ACTIVATE BRAND >>>>>>>>>\n" +
                              "___________________________________\n");

                Console.Write("___________________________________\n" +
                              "\n" +
                              "<<<<<<<<< DEACTIVE BRANDS >>>>>>>\n");
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

                ActivateBrand(emailOrPhone, password);
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
































    public void CategoriesMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<< CATEGORIES MENU >>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n" +
                          "[1|Add]\n" +
                          "[2|Activate]\n" +
                          "[3|Deactivate]\n" +
                          "[4|Change name]\n" +
                          "[5|Show all categories]\n" +
                          "[0]Back");
    }
    public void DiscountsMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<< DISCOUNTS MENU >>>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n" +
                          "[1|Add]\n" +
                          "[2|Activate]\n" +
                          "[3|Deactivate]\n" +
                          "[4|Change name]\n" +
                          "[5|Change percentage]\n" +
                          "[6|Show all Discounts]\n" +
                          "[0]Back");
    }
    public void UsersMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<<<< Users Menu >>>>>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n" +
                          "[1|Activate]\n" +
                          "[2|Deactivate]\n" +
                          "[3|Show all users]\n" +
                          "[4|Make admin]\n" +
                          "[5|Disable admin]\n" +
                          "[0]Back");
    }
    public void EditProfile(string emailOrPhone)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("___________________________________\n" +
                          "\n" +
                          "<<<<<<<<<<< Edit Profile >>>>>>>>>>\n" +
                          "___________________________________\n" +
                          "\n" +
                          "[1|Change name and lastname]\n" +
                          "[2|Change email]\n" +
                          "[3|Change password]\n" +
                          "[4|Change phone number]\n" +
                          "[5|Change birth date]\n" +
                          "[0]Back");
    }
}