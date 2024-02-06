using Shop.Core.Entities;

namespace Shop.Business.Interfaces;

public interface IUserServices
{
    Task<User> Create(string name, string lastname, string birthDay, string birthMonth, string birthYear,
       string phoneNumber, string email, string password);
    void ChangePassword(string email, string oldPassword, string newPassword);
    void ChangeEmail(string email, string password, string newEmail);
    void ChangePhone(string email, string password, string newPhone);
    void ChangeNameAndLastname(string email, string newName, string newLastname);
    void ChangeBirthDate(string email, string birthDay, string birthMonth, string birthYear);
    void MakeAdmin(int userId);
    void DisableAdmin(int userId);
    void ShowAllUsers();
}
