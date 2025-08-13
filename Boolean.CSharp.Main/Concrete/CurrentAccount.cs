using Boolean.CSharp.Main.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(string customerName, string phoneNumber, BankBranch branch)
            : base(customerName, phoneNumber, branch)
        {
        }
    }
}
