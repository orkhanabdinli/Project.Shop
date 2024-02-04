using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;
public class UserServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async void Create(string name, string lastname, string birthDay, string birthMonth, string birthYear, 
        string phoneNumber, string email, string password)
    {
        string birthDate = $"{birthYear}.{birthMonth}.{birthDay}";
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        if (String.IsNullOrEmpty(lastname)) throw new ArgumentNullException("You must enter lastname");
        if (DateTime.TryParse(birthDate, out DateTime result)) throw new WrongFormatException("Wrong date format entered");
        TimeSpan age = DateTime.Now - result;
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
            Birthday = result,
            PhoneNumber = phoneNumber,
            Email = email,
            Password = password,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now
        };
        await shopDbContext.Users.AddAsync(user);
        await shopDbContext.SaveChangesAsync();
    }
}
