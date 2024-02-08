namespace Shop.Business.Utilities.Helpers;

public enum Menu1
{
    LogIn = 1,
    Register 
}

public enum Menu2
{
    GoToRegister = 1,
    LogInAgain 
}

public enum Menu3
{
    GoToLogIn = 1,
    RegisterAgain 
}

public enum Adminmenu
{
    Products = 1,
    Brands,
    Category,
    Discounts,
    Users,
    EditProfile
}

public enum Productsmenu
{
    Add = 1,
    Activate,
    Deactivate, 
    ApplyDiscount,
    ChangeName,
    ChangeDescription,
    ChangePrice,          
    ChangeStock,                     
    ChangeBrand,                    
    ChangeCategory,   
    ShowAllProducts          
}

public enum Brandsmenu
{
    Add = 1,
    Activate,
    Deactivate,
    ChangeName,
    ShowAllBrands
}

public enum Categoriesmenu
{
    Add = 1,
    Activate,
    Deactivate,
    ChangeName,
    ShowAllCategories
}

public enum Discountsmenu
{
    Add = 1,
    Activate,
    Deactivate,
    ChangeName,
    ChangePercentage,
    ShowAllDiscounts
}

public enum EditUsersmenu
{
    Activate = 1,
    Deactivate,
    MakeAdmin,
    DisableAdmin,
    ShowAllUsers
}

public enum EditProfilesmenu
{
    ChangePassword = 1,
    ChangeEmail,
    ChangePhone,
    ChangeNameAndLastname,
    ChangeBirthDate
}

public enum Usermenu
{
    Products = 1,
    Cart,
    Wallet,
    EditProfile
}

public enum UserProductmenu
{
    SearchInProducts = 1,
    ShowAllProducts,
    ShowAllProductsByBrand,
    ShowAllProductsByCategory,
}

public enum Actionmenu
{
    AddToCart = 1,
    Buy
}

public enum Cartmenu
{
    ShowProductsInCart = 1,
    RemoveFromCart
}

public enum Walletmenu
{
    AddCard = 1,
    ActivateCard,
    DectivateCard,
    ShowAllCards,
    ChangeCardName,
    AddToBalance
}
