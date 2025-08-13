using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Concrete;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [Test] // user story 1, current account creation
        public void CreateCurrentAccount()
        {
            CurrentAccount currentAccount = new CurrentAccount
            {
                PhoneNumber = "123-456-7890",
                CustomerName = "Dimitar Berbatov"
            };
            Assert.IsNotNull(currentAccount);
            Assert.IsNotEmpty(currentAccount.PhoneNumber);
            Assert.IsNotNull(currentAccount.Id);
        }
        [Test] // user story 2, savings account creation
        public void CreateSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount
            {
                PhoneNumber = "123-456-7190",
                CustomerName = "Wayne Rooney"
            };
            Assert.IsNotNull(savingsAccount);
            Assert.IsNotEmpty(savingsAccount.PhoneNumber);
            Assert.IsNotNull(savingsAccount.Id);
        }

        [Test] // user story 1 and 2, cannot create savings account with invalid customer name
        public void CreateSavingsAccountFails()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            Assert.Throws<ArgumentException>(() => savingsAccount.CustomerName = "Ronaldinho");
        }

        [Test] // user story 3, generate bank statement
        public void PrintBankStatement()
        {
            CurrentAccount currentAccount = new CurrentAccount
            {
                PhoneNumber = "888-456-7890",
                CustomerName = "Lionel Messi"
            };
            currentAccount.Deposit(1000.00m);
            currentAccount.Deposit(2000.00m);
            currentAccount.Withdraw(500.00m);

            Assert.DoesNotThrow(() => currentAccount.PrintBankStatement());
        }

        [Test] // user story 4, bank withdrawal and deposit
        public void WithdrawAndDepositMoney()
        {
            CurrentAccount currentAccount = new CurrentAccount
            {
                PhoneNumber = "888-456-7890",
                CustomerName = "Zlatko Tripic"
            };
            currentAccount.Deposit(1000.00m);
            currentAccount.Deposit(2000.00m);
            currentAccount.Withdraw(500.00m);

            Assert.That(currentAccount.Balance, Is.EqualTo(2500.00m));
            Assert.That(currentAccount.GetPaymentHistory().Count, Is.EqualTo(3));
            Assert.That(currentAccount.GetPaymentHistory()[0].Amount, Is.EqualTo(1000.00m));
            Assert.That(currentAccount.GetPaymentHistory()[1].Amount, Is.EqualTo(2000.00m));
            Assert.That(currentAccount.GetPaymentHistory()[2].Amount, Is.EqualTo(-500.00m));
            Assert.Throws<InvalidOperationException>(() => currentAccount.Withdraw(3000.00m)); // Trying to withdraw more than balance
        }
    }
}