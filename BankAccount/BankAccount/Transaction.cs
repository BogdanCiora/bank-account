using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Transaction
    { 

        /*
        public decimal AmountRON { get; set; }

        public decimal AmountEUR { get; set; }

        public decimal AmountUSD { get; set; }
        */

        public decimal Amount { get; set; }
        public String CurrencyType { get; set; }
        public DateTime Date { get; set; }
        public String Notes { get; set; }

        public Transaction(decimal amount, string currency, DateTime date, string note)
        {
            /*
            if (currency == "RON")
            {
                this.AmountRON = amount;
            }
            else if (currency == "EUR")
            {
                this.AmountEUR = amount;
            }
            else if (currency == "USD")
            {
                this.AmountUSD = amount;
            }
            */

            this.Amount = amount;
            this.CurrencyType = currency;
            this.Date = date;
            this.Notes = note;
        }


    }
}
