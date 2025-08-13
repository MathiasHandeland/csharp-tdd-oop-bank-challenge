
using Boolean.CSharp.Main.Concrete;

CurrentAccount currentAccount = new CurrentAccount
{
    PhoneNumber = "123-456-7890",
    CustomerName = "Mathias Handeland"

};

currentAccount.Deposit(1000.00m);
currentAccount.Deposit(2000.00m);
currentAccount.Withdraw(500.00m);

currentAccount.PrintBankStatement();