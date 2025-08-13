using Boolean.CSharp.Main;
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
            CurrentAccount currentAccount = new CurrentAccount("Dimitar Berbatov", "123-456-7890", BankBranch.Trondheim);
            
            Assert.IsNotNull(currentAccount);
            Assert.IsNotEmpty(currentAccount.PhoneNumber);
            Assert.IsNotNull(currentAccount.Id);
            Assert.That(currentAccount.CustomerName, Is.EqualTo("Dimitar Berbatov"));
            Assert.That(currentAccount.Branch, Is.EqualTo(BankBranch.Trondheim));
            Assert.That(currentAccount.GetBalance(), Is.EqualTo(0m));
            Assert.That(currentAccount.GetPaymentHistory().Count, Is.EqualTo(0));
        }

        [Test] // user story 2, savings account creation
        public void CreateSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount("Wayne Rooney", "123-456-7190", BankBranch.Stavanger);
            
            Assert.IsNotNull(savingsAccount);
            Assert.IsNotEmpty(savingsAccount.PhoneNumber);
            Assert.IsNotNull(savingsAccount.Id);
            Assert.That(savingsAccount.CustomerName, Is.EqualTo("Wayne Rooney"));
            Assert.That(savingsAccount.Branch, Is.EqualTo(BankBranch.Stavanger));
            Assert.That(savingsAccount.GetBalance(), Is.EqualTo(0m));
            Assert.That(savingsAccount.GetPaymentHistory().Count, Is.EqualTo(0));
        }

        [Test] // user story 1 and 2, cannot create savings account with invalid customer name
        public void CreateSavingsAccountFails()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                // Only one name, should fail and the account cannot be made
                var savingsAccount = new SavingsAccount("Ronaldinho", "123-456-7190", BankBranch.Stavanger);
            });
        }

        [Test] // user story 3, generate bank statement
        public void PrintBankStatement()
        {
            CurrentAccount currentAccount = new CurrentAccount("Lionel Messi", "888-456-7890", BankBranch.Oslo);
            ConsolePrinter consolePrinter = new ConsolePrinter();

            currentAccount.Deposit(1000.00m);
            currentAccount.Deposit(2000.00m);
            currentAccount.Withdraw(500.00m);

            Assert.DoesNotThrow(() => currentAccount.PrintBankStatement(consolePrinter));  
        }

        [Test] // user story 4, bank withdrawal and deposit
        public void WithdrawAndDepositMoney()
        {
            SavingsAccount savingsAccount = new SavingsAccount("Zlatko Tripic", "888-456-7890", BankBranch.Stavanger);

            savingsAccount.Deposit(1000.00m);
            savingsAccount.Deposit(2000.00m);
            savingsAccount.Withdraw(500.00m);

            Assert.That(savingsAccount.GetBalance(), Is.EqualTo(2500.00m));
            Assert.That(savingsAccount.GetPaymentHistory().Count, Is.EqualTo(3));
            Assert.That(savingsAccount.GetPaymentHistory()[0].Amount, Is.EqualTo(1000.00m));
            Assert.That(savingsAccount.GetPaymentHistory()[1].Amount, Is.EqualTo(2000.00m));
            Assert.That(savingsAccount.GetPaymentHistory()[2].Amount, Is.EqualTo(-500.00m));
            Assert.Throws<InvalidOperationException>(() => savingsAccount.Withdraw(3000.00m)); // Trying to withdraw more than balance
        }
    }
}