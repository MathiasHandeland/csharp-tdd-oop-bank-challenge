
using Boolean.CSharp.Main.Concrete;

CurrentAccount currentAccount = new CurrentAccount
{
    PhoneNumber = "123-456-7890",
    CustomerName = "Mathias Handeland"

};

SavingsAccount savingsAccount = new SavingsAccount
{
    PhoneNumber = "098-765-4321",
    CustomerName = "John Doe"
};

Console.WriteLine(savingsAccount.Id);