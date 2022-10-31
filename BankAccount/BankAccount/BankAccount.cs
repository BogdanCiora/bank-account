using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                /*
                decimal balanceRON = 0;
                decimal balanceEUR = 0;
                decimal balanceUSD = 0;
                */

                decimal balance = 0;

                foreach (var item in allTransactions)
                {

                    balance += item.Amount;

                    /*
                    if (item.CurrencyType == "RON")
                    {
                        balanceRON += item.AmountRON;
                    }
                    else if (item.CurrencyType == "EUR")
                    {
                        balanceEUR += item.AmountEUR;
                    }
                    else if (item.CurrencyType == "USD")
                    {
                        balanceUSD += item.AmountUSD;
                    }
                    */
                }

                return balance;
            }
        }

        public string Currency { get; set; }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();


        public BankAccount(string name, decimal initialBalance, string currency)
        {
            this.Owner = name;

            MakeDeposit(initialBalance, currency, DateTime.Now, "Initial Balance");

            this.Currency = currency;

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
        

        public virtual void MakeDeposit(decimal amount, string currency, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, currency, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, string currency, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdraw request");
            }
            var withdrawal = new Transaction(-amount, currency, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            //HEADERS
            report.AppendLine("Date\t\t\tAmount\t\tCurrency\t\tNote");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Date}\t{item.Amount}\t\t{item.CurrencyType}\t\t{item.Notes}");
            }
            return report.ToString();
        }

    }
}
