// See https://aka.ms/new-console-template for more information
using Shop.Business.Services;
using Shop.DataAccess;
UserServices userServices = new();
WalletServices walletServices = new();
ProductServices productServices = new();
BrandServices brandServices = new();
CategoryServices categoryServices = new();
DiscountServices discountServices = new();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("   _____ _    _  ____  _____  _____ _____ _   _  _____              _____  _____      _____  _____   ____       _ ______ _____ _______ \r\n  / ____| |  | |/ __ \\|  __ \\|  __ \\_   _| \\ | |/ ____|       /\\   |  __ \\|  __ \\    |  __ \\|  __ \\ / __ \\     | |  ____/ ____|__   __|\r\n | (___ | |__| | |  | | |__) | |__) || | |  \\| | |  __       /  \\  | |__) | |__) |   | |__) | |__) | |  | |    | | |__ | |       | |   \r\n  \\___ \\|  __  | |  | |  ___/|  ___/ | | | . ` | | |_ |     / /\\ \\ |  ___/|  ___/    |  ___/|  _  /| |  | |_   | |  __|| |       | |   \r\n  ____) | |  | | |__| | |    | |    _| |_| |\\  | |__| |    / ____ \\| |    | |        | |    | | \\ \\| |__| | |__| | |___| |____   | |   \r\n |_____/|_|  |_|\\____/|_|    |_|   |_____|_| \\_|\\_____|   /_/    \\_\\_|    |_|        |_|    |_|  \\_\\\\____/ \\____/|______\\_____|  |_|   \r\n                                                                                                                                       \r\n                                                                                                                                       ");

//try
//{
//    Console.Write("Enter name:");
//    string? name = Console.ReadLine();
//    Console.Write("Enter lastname:");
//    string? lastname = Console.ReadLine();
//    Console.WriteLine("Enter birthday");
//    Console.Write("Enter day:");
//    string? day = Console.ReadLine();
//    Console.Write("Enter month:");
//    string? month = Console.ReadLine();
//    Console.Write("Enter year:");
//    string? year = Console.ReadLine();
//    Console.Write("Enter phone number:");
//    string? phone = Console.ReadLine();
//    Console.Write("Enter email address:");
//    string? email = Console.ReadLine();
//    Console.Write("Create password:");
//    string? password = Console.ReadLine();


//    await userServices.Create(name, lastname, day, month, year, phone, email, password);
//}
//catch (Exception ex)
//{
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine(ex.Message);
//    Console.ResetColor();
//}

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
