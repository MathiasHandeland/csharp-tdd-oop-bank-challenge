using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Concrete;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {

        [Test] // extention user story 1, balance should not be stored in memory, but calculated from transaction history
        public void BalanceIsCalculatedFromTransactionHistory()
        {
            SavingsAccount savingsAccount = new SavingsAccount("Cristiano Ronaldo", "133-456-7890", BankBranch.Trondheim);

            savingsAccount.Deposit(1000m);
            savingsAccount.Deposit(2000m);
            savingsAccount.Withdraw(500m);

            Assert.That(savingsAccount.GetBalance(), Is.EqualTo(2500m));
            Assert.That(savingsAccount.GetPaymentHistory().Count, Is.EqualTo(3));
            Assert.That(savingsAccount.GetPaymentHistory()[0].Amount, Is.EqualTo(1000m));
            Assert.That(savingsAccount.GetPaymentHistory()[1].Amount, Is.EqualTo(2000m));
            Assert.That(savingsAccount.GetPaymentHistory()[2].Amount, Is.EqualTo(-500m));
        }

        [Test] // extention, user story 2. bankaccounts should be assosiated with a spesific branch
        public void BankAccountIsAssociatedWithBranch()
        {
            SavingsAccount savingsAccount = new SavingsAccount("Nemanja Vidic", "133-555-7760", BankBranch.Trondheim);

            Assert.That(savingsAccount.Branch, Is.EqualTo(BankBranch.Trondheim));
        }

        [Test] // extention, user story 3. overdrafts can be requested
        public void RequestOverdraft()
        {
            CurrentAccount currentAccount = new CurrentAccount("Viljar Vevatne", "123-555-7760", BankBranch.Trondheim);

            currentAccount.RequestOverdraft(500m);
            Assert.That(currentAccount.OverdraftLimit, Is.EqualTo(500m));
            Assert.DoesNotThrow(() => currentAccount.Withdraw(500)); // should not throw as overdraft of 500 is allowed
            Assert.Throws<ArgumentException>(() => currentAccount.RequestOverdraft(-100m)); // requesting overdraft with negative amount should throw exception
            Assert.Throws<InvalidOperationException>(() => currentAccount.Withdraw(501)); // requesting overdraft of 500 and trying to withdraw 501 should throw exception
        }
    }
}
