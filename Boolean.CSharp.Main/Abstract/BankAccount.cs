using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main.Abstract
{
    public class BankAccount
    {
        private string _customerName;
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public string PhoneNumber { get; set; }
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
