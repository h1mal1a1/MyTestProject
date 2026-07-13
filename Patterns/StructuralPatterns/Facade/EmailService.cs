namespace MyTestProject.Patterns.StructuralPatterns.Facade;
public class EmailService
{
    public void SendOrderConfirmation(long userId)
    {
        Console.WriteLine($"Send order confirmation to user {userId}");
    }
}