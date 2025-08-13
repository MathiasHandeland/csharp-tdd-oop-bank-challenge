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

    }
}