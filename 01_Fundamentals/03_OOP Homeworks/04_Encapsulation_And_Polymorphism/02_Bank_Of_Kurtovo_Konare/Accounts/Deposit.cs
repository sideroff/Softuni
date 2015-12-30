using System;
using System.Security.Cryptography;

namespace _02_Bank_Of_Kurtovo_Konare.Accounts
{
    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
               : base(customer, balance, interestRate)
        {
        }

        public override void Withdraw(decimal ammount)
        {
            if (Balance - ammount < 0) Console.WriteLine("Insufficient funds.");
            Console.WriteLine("Balance before withdraw: " + this.Balance + " Balance after withdraw: " + (this.Balance - ammount));
            this.Balance -= ammount;
        }

        public override decimal CalculateInterest(int months)
        {

            if (0 < this.Balance && this.Balance < 1000)
            {
                return base.CalculateInterest(0);
            }

            return base.CalculateInterest(months);
            
        }
    }
}