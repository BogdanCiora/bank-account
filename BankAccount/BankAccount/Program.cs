using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {
        public static List<User> allUsers = new List<User>();
        public static List<BankAccount> allBankAccounts = new List<BankAccount>();
        public static List<SavingsAccount> allSavings = new List<SavingsAccount>();

        public static void LoginMenu()
        {
            Console.Clear();

            bool loginFailed = false;

            do
            {
                Console.WriteLine("LOGIN");
                Console.WriteLine();
                Console.Write("Available username types: ");

                foreach (var item in allUsers)
                {
                    Console.Write(item.UsernameType + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();

                Console.Write("Username Type: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();

                foreach (var item in allUsers)
                {
                    if (item.UsernameType == "Admin" && item.Password == password)
                        AdminMenu();
                    else if (item.UsernameType == "Normal" && item.Password == password)
                        NormalMenu();
                    else if (item.UsernameType == "Limited" && item.Password == password)
                        LimitedMenu();
                    else
                        loginFailed = true;
                }
            } while (loginFailed == false);

            LoginMenu();

        }

        public static void AdminMenu()
        {
            Console.Clear();

            bool isValid = true;

            do
            {

                Console.WriteLine("1. Add one account");
                Console.WriteLine("2. Show accounts");
                Console.WriteLine("3. Withdraw from account");
                Console.WriteLine("4. Deposit to account");
                Console.WriteLine("5. Check specific account balance");
                Console.WriteLine("6. Check specific account history");
                Console.WriteLine();
                Console.WriteLine("7. Save money");
                Console.WriteLine("8. Save more money");
                Console.WriteLine("9. Show savings accounts");
                Console.WriteLine();
                Console.WriteLine("10. Exit");
                Console.WriteLine("");
                Console.Write("Enter option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBankAccount();
                        break;
                    case "2":
                        ShowAccounts();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        Deposit();
                        break;
                    case "5":
                        CheckSpecificBalance();
                        break;
                    case "6":
                        CheckSpecificHistory();
                        break;
                    case "7":
                        SaveMoney();
                        break;
                    case "8":
                        SaveMoreMoney();
                        break;
                    case "9":
                        ShowSavingsAccounts();
                        break;
                    case "10":
                        isValid = false;
                        break;
                }
            }
            while (isValid);

            LoginMenu();
        }

        public static void NormalMenu()
        {
            Console.Clear();

            bool isValid = true;

            do
            {

                Console.WriteLine("1. Add one account");
                Console.WriteLine("2. Withdraw from account");
                Console.WriteLine("3. Deposit to account");
                Console.WriteLine("4. Check specific account balance");
                Console.WriteLine("5. Check specific account history");
                Console.WriteLine();
                Console.WriteLine("6. Save money");
                Console.WriteLine("7. Save more money");
                Console.WriteLine();
                Console.WriteLine("8. Exit");
                Console.WriteLine("");
                Console.Write("Enter option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBankAccount();
                        break;
                    case "2":
                        Withdraw();
                        break;
                    case "3":
                        Deposit();
                        break;
                    case "4":
                        CheckSpecificBalance();
                        break;
                    case "5":
                        CheckSpecificHistory();
                        break;
                    case "6":
                        SaveMoney();
                        break;
                    case "7":
                        SaveMoreMoney();
                        break;
                    case "8":
                        isValid = false;
                        break;
                }
            }
            while (isValid);

            LoginMenu();
        }

        public static void LimitedMenu()
        {
            Console.Clear();

            bool isValid = true;

            do
            {

                Console.WriteLine("1. Add one account");
                Console.WriteLine();
                Console.WriteLine("2. Save money");
                Console.WriteLine();
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Enter option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBankAccount();
                        break;
                    case "2":
                        SaveMoney();
                        break;
                    case "3":
                        isValid = false;
                        break;
                }
            }
            while (isValid);

            LoginMenu();
        }

        public static void AddBankAccount()
        {
            Console.Clear();

            Console.Write("New account name: ");
            var name = Console.ReadLine();
            Console.Write("First deposit amount: ");
            var deposit = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Currency(RON/EUR/USD): ");
            var currency = Console.ReadLine();

            var account = new BankAccount(name, deposit, currency);

            allBankAccounts.Add(account);

            Console.Clear();
        }

        public static void ShowAccounts()
        {
            Console.Clear();

            foreach (var item in allBankAccounts)
            {
                Console.WriteLine("Client name: " + item.Owner);
                Console.WriteLine("Balance: " + item.Balance);
                Console.WriteLine("Currency: " + item.Currency);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Withdraw()
        {
            Console.Clear();

            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            Console.Write("Enter value to withdraw: ");
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter currency of the withdrawal: ");
            string currency = Console.ReadLine();

            Console.Write("Note: ");
            string noteMessage = Console.ReadLine();

            foreach (var item in allBankAccounts)
            {
                if (item.Owner == name)
                    item.MakeWithdrawal(withdrawAmount, currency, DateTime.Now, noteMessage);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(); 
            Console.Clear();
        }

        public static void Deposit()
        {
            Console.Clear();

            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            Console.Write("Enter value to deposit: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter the currency of the deposit: ");
            var currency = Console.ReadLine();

            Console.Write("Note: ");
            string noteMessage = Console.ReadLine();

            foreach (var item in allBankAccounts)
            {
                if (item.Owner == name)
                    item.MakeDeposit(depositAmount, currency, DateTime.Now, noteMessage);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void CheckSpecificBalance()
        {
            Console.Clear();

            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            foreach (var item in allBankAccounts)
            {
                if (item.Owner == name)
                    Console.WriteLine($"Balance for {item.Owner} is {item.Balance}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void CheckSpecificHistory()
        {
            Console.Clear();

            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            foreach (var item in allBankAccounts)
            {
                if (item.Owner == name)
                    Console.WriteLine(item.GetAccountHistory());
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void SaveMoney()
        {
            Console.Clear();

            Console.Write("New account name: ");
            var name = Console.ReadLine();
            Console.Write("First deposit amount: ");
            var deposit = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Currency(RON/EUR/USD): ");
            var currency = Console.ReadLine();
            Console.Write("Period of time: ");
            var period = Convert.ToInt32(Console.ReadLine());

            var account = new SavingsAccount(name, deposit, currency, period);

            allSavings.Add(account);

            Console.Clear();
        }

        public static void SaveMoreMoney()
        {
            Console.Clear();

            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            Console.Write("Enter value to save: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Currency(RON/EUR/USD): ");
            var currency = Console.ReadLine();

            Console.Write("Note: ");
            string noteMessage = Console.ReadLine();

            Console.Write("Period of time: ");
            decimal period = Convert.ToInt32(Console.ReadLine());

            decimal interest;

            if (period <= 0)
                interest = 2;
            else if (period < 2)
                interest = 4;
            else
                interest = 6;

            foreach (var item in allSavings)
            {
                if (item.Owner == name)
                    item.MakeDepositSavings(depositAmount, currency, DateTime.Now, noteMessage, interest);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowSavingsAccounts()
        {
            Console.Clear();

            foreach (var item in allSavings)
            {
                Console.WriteLine("Client name: " + item.Owner);
                Console.WriteLine("Balance: " + item.Balance);
                Console.WriteLine("Currency: " + item.Currency);
                Console.WriteLine("Interest rate: " + item.interestRate);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            User Admin = new User("Admin", "Admin");
            User Normal = new User("Normal", "Normal");
            User Limited = new User("Limited", "Limited");

            allUsers.Add(Admin);
            allUsers.Add(Normal);
            allUsers.Add(Limited);

            LoginMenu();

            Console.ReadLine();
        }
    }
}
