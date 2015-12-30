namespace _02_Bank_Of_Kurtovo_Konare
{
    public interface IAccount
    {
        Customer Customer { get; set; }
        decimal Balance { get; set; }
        decimal InterestRate { get; set; }
        void Deposit(decimal ammount);
        void Withdraw(decimal ammount);
        decimal CalculateInterest(int months);
    }
}