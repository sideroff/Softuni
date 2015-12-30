namespace _02_Bank_Of_Kurtovo_Konare.Accounts
{
    public class Mortrage : Account
    {
        public Mortrage(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            int monthsForHalfInterest = 6;
            if (this.Customer == Customer.Individual)
            {
                monthsForHalfInterest = 12;
            }
            {
                if (months <= monthsForHalfInterest) return base.CalculateInterest(months)/2;
                else
                {
                    return (base.CalculateInterest(monthsForHalfInterest)/2) + (base.CalculateInterest(months - monthsForHalfInterest));
                }
            }
        }
    }
}