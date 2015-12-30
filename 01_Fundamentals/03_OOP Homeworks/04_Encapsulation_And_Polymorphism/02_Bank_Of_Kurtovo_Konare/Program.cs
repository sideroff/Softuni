using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_Bank_Of_Kurtovo_Konare.Accounts;

namespace _02_Bank_Of_Kurtovo_Konare
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(new Deposit(Customer.Individual, 100m, 1.25m));
            accounts.Add(new Deposit(Customer.Company, 200m, 2.25m));

            accounts.Add(new Loan(Customer.Individual, 300m, 3.25m));
            accounts.Add(new Loan(Customer.Company, 400m, 4.25m));

            accounts.Add(new Mortrage(Customer.Individual, 500m, 5.25m));
            accounts.Add(new Mortrage(Customer.Company, 600m, 6.25m));

            foreach (var account in accounts)
            {
                Console.WriteLine(account);
                account.Deposit(50);
                account.Withdraw(100);
                Console.WriteLine("Interest for 3 months: " + account.CalculateInterest(3));
                Console.WriteLine("Interest for 8 months: " + account.CalculateInterest(8));
                Console.WriteLine("Interest for 15 months: " + account.CalculateInterest(15));
                Console.WriteLine(account);
                Console.WriteLine();
            }

        }
    }
}
