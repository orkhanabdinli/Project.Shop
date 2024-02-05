// See https://aka.ms/new-console-template for more information
using Shop.Business.Services;
using Shop.DataAccess;

Console.WriteLine("Hello, World!");

ShopDbContext db = new ShopDbContext();

//DateTime dateTime = DateTime.Now;
//DateTime enteredTime = new DateTime(2003, 05, 05, 12, 45, 45);
//TimeSpan difference = dateTime - enteredTime;
//Console.WriteLine(difference.);
//if (difference.Days / 365 < 18)
//    Console.WriteLine("You are not 18 yet");


//using Shop.Business.Services;

//DateTime enteredTime = new DateTime(2003, 05, 05, 12, 45, 45);

//UserServices userServices = new UserServices();

//userServices.Create("Orkhan", "Abdinli", "1", "11", "2000", "+994508580290", "ao@gmail.com", "orxan2000", DateTime.Now, DateTime.Now);

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

UserServices userServices = new UserServices();
try
{
    Console.Write("Enter name:");
    string? name = Console.ReadLine();
    Console.Write("Enter lastname:");
    string? lastname = Console.ReadLine();
    Console.WriteLine("Enter birthday");
    Console.Write("Enter day:");
    string? day = Console.ReadLine();
    Console.Write("Enter month:");
    string? month = Console.ReadLine();
    Console.Write("Enter year:");
    string? year = Console.ReadLine();
    Console.Write("Enter phone number:");
    string? phone = Console.ReadLine();
    Console.Write("Enter email address:");
    string? email = Console.ReadLine();
    Console.Write("Create password:");
    string? password = Console.ReadLine();


    await userServices.Create(name, lastname, day, month, year, phone, email, password);
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}
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
//await walletServices.Create("Card1", "1234567887654321", 1);

