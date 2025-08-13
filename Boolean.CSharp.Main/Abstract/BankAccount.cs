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
        private List<Transaction> _transactions = new List<Transaction>();

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            _transactions.Add(new Transaction // Create a new transaction for the deposit and store info of the transaction
            {
                Account = AccountNumber,
                Amount = amount,
                Date = DateTime.Now,
                BalanceAfterTransaction = GetBalance() + amount // Store the balance after the transaction
            });
        }

        public void Withdraw(decimal amount)
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
        

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                // if the does not contain 8 digits, throw an exception
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

        public void PrintBankStatement()
        {
            Console.WriteLine("date       || credit  ||  debit  || balance");

            foreach (var transaction in _transactions.OrderByDescending(t => t.Date)) // transactions are sorted with the most recent first
            {
                string date = transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                string credit = transaction.Amount > 0 ? transaction.Amount.ToString("F2") : ""; // f2 for two decimal places, credit is a deposit
                string debit = transaction.Amount < 0 ? Math.Abs(transaction.Amount).ToString("F2") : ""; // debit is a withdrawel
                string balance = transaction.BalanceAfterTransaction.ToString("F2"); // shows the balance after the transaction

                Console.WriteLine("{0,-10} || {1,7} || {2,7} || {3,6}", date, credit, debit, balance);
            }
        }
    }
}
