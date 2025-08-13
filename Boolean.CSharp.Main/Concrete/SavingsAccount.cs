using Boolean.CSharp.Main.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Concrete
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string customerName, string phoneNumber, BankBranch branch)
            : base(customerName, phoneNumber, branch)
        {
        }
    }
}