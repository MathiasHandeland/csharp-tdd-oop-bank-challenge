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
            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.CustomerName = "Cristiano Ronaldo";
            
            savingsAccount.Deposit(1000m);
            savingsAccount.Deposit(2000m);
            savingsAccount.Withdraw(500m);

            Assert.That(savingsAccount.GetBalance(), Is.EqualTo(2500m));
            Assert.That(savingsAccount.GetPaymentHistory().Count, Is.EqualTo(3));
            Assert.That(savingsAccount.GetPaymentHistory()[0].Amount, Is.EqualTo(1000m));
            Assert.That(savingsAccount.GetPaymentHistory()[1].Amount, Is.EqualTo(2000m));
            Assert.That(savingsAccount.GetPaymentHistory()[2].Amount, Is.EqualTo(-500m));
        }
    }
}
