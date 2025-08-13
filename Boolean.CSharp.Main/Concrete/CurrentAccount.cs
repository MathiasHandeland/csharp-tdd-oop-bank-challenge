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
            if (newBalance < -OverdraftLimit)
            {
                throw new InvalidOperationException("Withdrawal would exceed overdraft limit.");
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
            OverdraftLimit = amount; // Set the overdraft limit for the account
        }
        public decimal OverdraftLimit { get; set; } // determines how much overdraft to the account is allowed
    }
}
