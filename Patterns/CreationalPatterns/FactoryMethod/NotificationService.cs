namespace MyTestProject.Patterns.CreationalPatterns.FactoryMethod;
    public class NotificationService
    {
        //Пример без фабрики
        public void Send(string type, string message)
        {
            if(type == "email")
            {
                var sender = new EmailNotificationSender();
                sender.Send(message);
            }
            else if(type == "sms")
            {
                var sender = new SmsNotificationSender();
                sender.Send(message);
            }
        }

        //Пример с фабрикой
        public void SendWithFactory(string type, string message)
        {
            var factory = new NotificationSenderFactory();
            INotificationSender sender = factory.Create(type);
            sender.Send(message);
        }
    }