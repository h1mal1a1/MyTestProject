namespace MyTestProject.Patterns.CreationalPatterns.FactoryMethod;

public class NotificationSenderFactory
{
    public INotificationSender Create(string type)
    {
        return type switch
        {
            "email" => new EmailNotificationSender(),
            "sms" => new SmsNotificationSender(),
            _ => throw new ArgumentException("Invalid notification type")
        };
    }
}