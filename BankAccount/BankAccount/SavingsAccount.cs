using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class SavingsAccount : BankAccount
    {
        public decimal interestRate;
        public decimal periodOfDeposit;

        public new decimal Balance {
            get
            {
                decimal balance = 0;

                foreach (var item in allInvestments)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        public List<Investment> allInvestments = new List<Investment>();

        public SavingsAccount(string name, decimal initialBalance, string currency, decimal period)
            : base(name, initialBalance, currency)
        {
            this.Owner = name;
            this.periodOfDeposit = period;

            if (period <= 0)
                this.interestRate = 2;
            else if (period < 2)
                this.interestRate = 4;
            else
                this.interestRate = 6;

            MakeDepositSavings(initialBalance, currency, DateTime.Now, "Initial Money Saving", this.interestRate);

        }

        public void MakeDepositSavings(decimal amount, string currency, DateTime date, string note, decimal interest)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Investment(amount, currency, date, note, interest);
            allInvestments.Add(deposit);
        }
    }
}
