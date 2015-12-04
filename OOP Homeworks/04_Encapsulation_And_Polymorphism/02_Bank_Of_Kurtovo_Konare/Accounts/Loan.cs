namespace _02_Bank_Of_Kurtovo_Konare.Accounts
{
    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {

            if (this.Customer == Customer.Individual)
            {
                return base.CalculateInterest(months - 3);
            }
            if (this.Customer == Customer.Company)
            {
                return base.CalculateInterest(months - 2);
            }
            return base.CalculateInterest(months);
        }
    }
}