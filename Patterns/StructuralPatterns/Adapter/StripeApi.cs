namespace MyTestProject.Patterns.StructuralPatterns.Adapter;

public class StripeApi
{
    public void MakePayment(decimal money)
    {
        // Реализация оплаты через Stripe API
        Console.WriteLine($"Оплата {money} через Stripe API");
    }
}