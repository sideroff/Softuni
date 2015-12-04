using System;
using System.Diagnostics.Eventing.Reader;

namespace _02_Bank_Of_Kurtovo_Konare
{
    public abstract class Account : IAccount
    {
        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public void Deposit(decimal ammount)
        {
            Console.WriteLine("Balance before deposit: " + this.Balance + " Balance after deposit: " + (this.Balance +ammount));
            this.Balance += ammount;
        }

        public virtual void Withdraw(decimal ammount)
        {
            Console.WriteLine("This account type does not support withdrawing.");
        }

        public virtual decimal CalculateInterest(int months)
        {
            return this.Balance*(1 + this.InterestRate*months);
        }

        public override string ToString()
        {
            return this.Customer.ToString() + Environment.NewLine +
                   this.Balance + Environment.NewLine +
                   this.InterestRate;
        }
    }
}