namespace _02.Customer
{
    public interface IPayment
    {
        //product name and price.
        string Name { get; } 
        decimal Price { get; }
    }
}