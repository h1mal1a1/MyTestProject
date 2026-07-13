namespace MyTestProject.Patterns.CreationalPatterns.FactoryMethod;

public class SmsNotificationSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS notification: {message}");
    }
}