using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Investment : Transaction
    {
        public decimal InterestR { get; set; }

        public Investment(decimal amount, string currency, DateTime date, string note, decimal interest)
            : base (amount, currency, date, note)
        {
            this.Amount = amount;
            this.InterestR = interest;
            this.Date = date;
            this.Notes = note;
        }

    }
}
