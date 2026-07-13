namespace MyTestProject.Patterns.CreationalPatterns.FactoryMethod;

public class EmailNotificationSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email notification: {message}");
    }
}