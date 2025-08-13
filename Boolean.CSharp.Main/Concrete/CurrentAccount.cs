using Boolean.CSharp.Main.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Concrete
{
    public class CurrentAccount : BankAccount
    {
        private decimal _requestedOverdraft; // private field to store the requested overdraft limit
        private bool _overdraftApproved; // private field to store if the overdraft is approved
        public CurrentAccount(string customerName, string phoneNumber, BankBranch branch)
            : base(customerName, phoneNumber, branch)
        {
        }
 
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            // Calculate the new balance as if this withdrawal is made to check if it exceeds the overdraft limit
            decimal newBalance = GetBalance() - amount;
            if (!_overdraftApproved && newBalance < 0) // if overdraft is not approved and the withdrawel requires overdraft no overdraft should be given
            {
                throw new InvalidOperationException("Overdraft not approved");
            }
            if (newBalance < -OverdraftLimit)
            {
                throw new InvalidOperationException("Withdrawal would exceed overdraft limit");
            }
            _transactions.Add(new Transaction // Create a new transaction for the withdrawal and store info of the transaction
            {
                Account = AccountNumber,
                Amount = -amount, // Negative amount for withdrawal
                Date = DateTime.Now,
                BalanceAfterTransaction = GetBalance() - amount // Store the balance after the transaction
            });
        }

        public void RequestOverdraft(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Overdraft limit must be greater than zero.");
            }
            _requestedOverdraft = amount;
            _overdraftApproved = false; // default as false
        }

        public void ApproveOverdraft()
        {
            _overdraftApproved = true; // Set the overdraft as approved
            OverdraftLimit = _requestedOverdraft; // set the limit of the overdraft to what was requested
        }

        public void RejectOverdraft()
        {
            _overdraftApproved = false; // Set the overdraft as rejected
            _requestedOverdraft = 0; // Reset the requested overdraft limit
            OverdraftLimit = 0;
        }

        public decimal OverdraftLimit { get; set; }

    }
}
