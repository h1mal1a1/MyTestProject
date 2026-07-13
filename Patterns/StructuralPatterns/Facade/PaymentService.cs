namespace MyTestProject.Patterns.StructuralPatterns.Facade;
public class PaymentService
{
    public void Pay(long userId, decimal amount)
    {
        Console.WriteLine($"User {userId} paid {amount}");
    }
}