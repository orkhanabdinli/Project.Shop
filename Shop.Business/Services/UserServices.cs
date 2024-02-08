using Microsoft.EntityFrameworkCore;
using Shop.Business.Interfaces;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;
public class UserServices 
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<User> Create(string name, string lastname, string birthDay, string birthMonth, string birthYear,
        string phoneNumber, string email, string password)
    {
        string birthDate = $"{birthYear} {birthMonth} {birthDay}";
        bool isDate = DateTime.TryParse(birthDate, out DateTime birthDate1);
        if (isDate != true) throw new WrongFormatException("Wrong birth date format");
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        if (String.IsNullOrEmpty(lastname)) throw new ArgumentNullException("You must enter lastname");
        TimeSpan age = DateTime.Now - birthDate1;
        if (age.Days < 6570) throw new AgeException("You must be older than 18");
        if (String.IsNullOrEmpty(phoneNumber)) throw new ArgumentNullException("You must enter phone number");
        if (String.IsNullOrEmpty(email)) throw new ArgumentNullException("You must enter email address");
        User? user1 = await shopDbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber || u.Email == email);
        if (user1 is not null && user1.PhoneNumber == phoneNumber) throw new AlreadyExistsException("This phone number is already in use");
        if (user1 is not null && user1.Email == email) throw new AlreadyExistsException("This email is already in use");
        if (String.IsNullOrEmpty(password)) throw new ArgumentNullException("You must enter password");
        if (password.Length < 5) throw new WeakPasswordException("Password must contain at least 5 symbols");
        User user = new User()
        {
            Name = name,
            Lastname = lastname,
            Birthday = birthDate1,
            PhoneNumber = phoneNumber,
            Email = email,
            Password = password
        };
        await shopDbContext.Users.AddAsync(user);
        await shopDbContext.SaveChangesAsync();
        return user;
    }
    public bool LogIn(string? emailOrPhone, string? password)
    {
        if (String.IsNullOrEmpty(emailOrPhone) || String.IsNullOrEmpty(password)) throw new WrongFormatException("Email address/phone or password can not be null"); 
        User? user = shopDbContext.Users.FirstOrDefault(u => (u.Email == emailOrPhone && u.Password == password) || (u.PhoneNumber == emailOrPhone && u.Password == password));
        if (user is null || user.IsActive == false) throw new NotFoundException("     Incorrect email address or password");
        return true;
    }
    public void ChangePassword(string email, string oldPassword, string newPassword)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);
        if (user.Password == oldPassword)
        {
            user.Password = newPassword;
            user.LastModifiedDate = DateTime.UtcNow;
            shopDbContext.Entry(user).State = EntityState.Modified;
            shopDbContext.SaveChanges();
        }
        else throw new DoesntMatchException("Wrong password entered");
    }
    public void ChangeEmail(string email, string password, string newEmail)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);
        var user1 = shopDbContext.Users.FirstOrDefault(u => u.Email == newEmail);
        if (user1 is not null) throw new IsAlreadyException("This email is already in use");
        if (user.Password == password)
        {
            user.Email = newEmail;
            user.LastModifiedDate = DateTime.UtcNow;
            shopDbContext.Entry(user).State = EntityState.Modified;
            shopDbContext.SaveChanges();
        }
        else throw new DoesntMatchException("Wrong password entered");
    }
    public void ChangePhone(string email, string password, string newPhone)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);
        var user1 = shopDbContext.Users.FirstOrDefault(u => u.PhoneNumber == newPhone);
        if (user1 is not null) throw new IsAlreadyException("This phone number is already in use");
        if (user.Password == password)
        {
            user.PhoneNumber = newPhone;
            user.LastModifiedDate = DateTime.UtcNow;
            shopDbContext.Entry(user).State = EntityState.Modified;
            shopDbContext.SaveChanges();
        }
        else throw new DoesntMatchException("Wrong password entered");
    }
    public void ChangeNameAndLastname(string email, string newName, string newLastname)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);

        user.Name = newName;
        user.Lastname = newLastname;
        user.LastModifiedDate = DateTime.UtcNow;
        shopDbContext.Entry(user).State = EntityState.Modified;
        shopDbContext.SaveChanges();
    }
    public void ChangeBirthDate(string email, string birthDay, string birthMonth, string birthYear)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);

        string birthDate = $"{birthYear} {birthMonth} {birthDay}";
        DateTime birthDate1 = DateTime.Parse(birthDate);
        user.Birthday = birthDate1;
        user.LastModifiedDate = DateTime.UtcNow;
        shopDbContext.Entry(user).State = EntityState.Modified;
        shopDbContext.SaveChanges();
    }
    public void MakeAdmin(int? userId)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.Find(userId);
        if (user.IsAdmin == true) throw new IsAlreadyException("The user is already admin");
        user.IsAdmin = true;
        user.LastModifiedDate = DateTime.UtcNow;
        shopDbContext.SaveChanges();
    }
    public void DisableAdmin(int? userId)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.Find(userId);
        if (user.IsAdmin == false) throw new IsAlreadyException("The user is already not admin");
        user.IsAdmin = false;
        user.LastModifiedDate = DateTime.UtcNow;
        shopDbContext.SaveChanges();
    }
    public void ActivateUser(int? userId)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.Find(userId);
        if (user.IsActive == true) throw new IsAlreadyException("The user is already active");
        user.IsActive = true;
        user.LastModifiedDate = DateTime.UtcNow;
        shopDbContext.SaveChanges();
    }
    public void DeactivateUser(int? userId)
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        User? user = shopDbContext.Users.Find(userId);
        if (user.IsActive == false) throw new IsAlreadyException("The user is already not active");
        user.IsActive = false;
        user.LastModifiedDate = DateTime.UtcNow;
        shopDbContext.SaveChanges();
    }
    public void ShowAllUsers() 
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        var users = shopDbContext.Users.AsNoTracking().ToList();
        foreach (var item in users)
        {
            string? admin = String.Empty;
            string? isActive = String.Empty;
            if (item.IsAdmin == true) 
            {
                admin = "Admin";
            }
            else { admin = "Not admin"; }
            
            if (item.IsActive == true) 
            {
                isActive = "Active";
            }
            else { isActive = "Not active"; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {item.Id}  Name: {item.Name}  Lastname: {item.Lastname} \n" +
                              $"Phone: {item.PhoneNumber}  Email: {item.Email}\n" +
                              $"Authority: {admin}\n" +
                              $"Status: {isActive}\n" +
                              "_______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowActiveUsers()
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        var users = shopDbContext.Users.Where(u => u.IsActive == true).AsNoTracking().ToList();
        foreach (var item in users)
        {
            string? admin = String.Empty;
            if (item.IsAdmin == true)
            {
                admin = "Admin";
            }
            else { admin = "Not admin"; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {item.Id}  Name: {item.Name}  Lastname: {item.Lastname} \n" +
                              $"Phone: {item.PhoneNumber}  Email: {item.Email}\n" +
                              $"Authority: {admin}\n" +
                              "_______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowDeactiveUsers()
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        var users = shopDbContext.Users.Where(u =>u.IsActive == false).AsNoTracking().ToList();
        foreach (var item in users)
        {
            string? admin = String.Empty;
            if (item.IsAdmin == true)
            {
                admin = "Admin";
            }
            else { admin = "Not admin"; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {item.Id}  Name: {item.Name}  Lastname: {item.Lastname} \n" +
                              $"Phone: {item.PhoneNumber}  Email: {item.Email}\n" +
                              $"Authority: {admin}\n" +
                              "_______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowAdminUsers()
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        var users = shopDbContext.Users.Where(u => u.IsAdmin == true).AsNoTracking().ToList();
        foreach (var item in users)
        {
            string? isActive = String.Empty;
            if (item.IsActive == true)
            {
                isActive = "Active";
            }
            else { isActive = "Not active"; }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {item.Id}  Name: {item.Name}  Lastname: {item.Lastname} \n" +
                              $"Phone: {item.PhoneNumber}  Email: {item.Email}\n" +
                              $"Status: {isActive}\n" +
                              "_______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowNotAdminUsers()
    {
        ShopDbContext shopDbContext = new ShopDbContext();
        var users = shopDbContext.Users.Where(u => u.IsAdmin == false).AsNoTracking().ToList();
        foreach (var item in users)
        {
            string? isActive = String.Empty;
            if (item.IsActive == true)
            {
                isActive = "Active";
            }
            else { isActive = "Not active"; }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {item.Id}  Name: {item.Name}  Lastname: {item.Lastname} \n" +
                              $"Phone: {item.PhoneNumber}  Email: {item.Email}\n" +
                              $"Status: {isActive}\n" +
                              "_______________________________________________________________");
            Console.ResetColor();
        }
    }
    public bool IsAdmin(string email, string password)
    {
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user.IsAdmin == true) return true;
        return false;
    }
    public bool IsAnyActiveUser()
    {
        var users = shopDbContext.Users.FirstOrDefault(u => u.IsActive == true);
        if (users is not null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsAnyDeactiveUser()
    {
        var users = shopDbContext.Users.FirstOrDefault(u => u.IsActive == false);
        if (users is not null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
