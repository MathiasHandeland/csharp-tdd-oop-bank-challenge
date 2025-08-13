using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main.Abstract
{
    public class BankAccount 
    {
        private string _phoneNumber; 
        private string _customerName; 
        protected List<Transaction> _transactions = new List<Transaction>(); // protected so it can be accessed by derived classes. Used in CurrentAccount

        public BankAccount(string customerName, string phoneNumber, BankBranch branch) // params needed to initalize a new bank account
        {
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            Branch = branch;
        }
        public void PrintBankStatement(IPrinter printer) // Print bank statement in a formatted way
        {
            var sb = new StringBuilder();
            sb.AppendLine("date       || credit  ||  debit  || balance");

            foreach (var transaction in _transactions.OrderByDescending(t => t.Date)) // transactions are sorted with the most recent first
            {
                string date = transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                string credit = transaction.Amount > 0 ? transaction.Amount.ToString("F2") : ""; // f2 for two decimal places, credit is a deposit
                string debit = transaction.Amount < 0 ? Math.Abs(transaction.Amount).ToString("F2") : ""; // debit is a withdrawel
                string balance = transaction.BalanceAfterTransaction.ToString("F2"); // shows the balance after the transaction

                sb.AppendLine($"{date,-10} || {credit,7} || {debit,7} || {balance,6}");
            }
            printer.Print(sb.ToString()); // Use the Print method from the IPrinter interface to print the statement either to console or sms via twilio
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            _transactions.Add(new Transaction // Create a new transaction for the deposit and store all associated info of this transaction
            {
                Account = AccountNumber,
                Amount = amount,
                Date = DateTime.Now,
                BalanceAfterTransaction = GetBalance() + amount // Store the balance after the transaction
            });
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if (GetBalance() < amount)
            {
                throw new InvalidOperationException("Don't have enough money in the account. Please check Balance before withdrawel");
            }
            _transactions.Add(new Transaction // Create a new transaction for the withdrawal and store info of the transaction
            {
                Account = AccountNumber,
                Amount = -amount, // Negative amount for withdrawal
                Date = DateTime.Now,
                BalanceAfterTransaction = GetBalance() - amount // Store the balance after the transaction
            });
        }

        public List<Transaction> GetPaymentHistory() => _transactions;

        public decimal GetBalance() => _transactions.Sum(t => t.Amount);
        

        public BankBranch Branch { get; set; }
        
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                // if the phone number does not contain 8 digits, throw an exception
                if (string.IsNullOrWhiteSpace(value) || value.Count(char.IsDigit) < 8)
                {
                    throw new ArgumentException("Phone number must contain at least 8 digits");
                }
            }
        }
               
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Split(' ').Length < 2)
                {
                    throw new ArgumentException("Customer name must include both first name and surname");
                }
                _customerName = value;
            }
        }
    }
}