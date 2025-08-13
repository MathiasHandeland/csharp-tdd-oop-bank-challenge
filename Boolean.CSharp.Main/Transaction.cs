using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Uniquely identifies the transaction
        public Guid Account { get; set; } // Account associated with the transaction
        public decimal Amount { get; set; } // Amount of money involved in the transaction
        public DateTime Date { get; set; } = DateTime.Now; // Date and time of the transaction 

        public decimal BalanceAfterTransaction { get; set; } // Balance after the transaction
    }
}
