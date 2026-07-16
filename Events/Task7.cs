namespace MyTestProject.Events;

public class Task7
{
    public class Publisher
    {
        public event EventHandler? Notification;

        public void SendNotification()
        {
            Notification?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Subscriber : IDisposable
    {
        Publisher Publ;

        public Subscriber(Publisher publisher)
        {
            Publ = publisher;
            Publ.Notification += HandleNotification;
        }

        public void HandleNotification(object? sender, EventArgs e)
        {
            Console.WriteLine("Подписчик получил уведомление");
        }

        public void Dispose()
        {
            Publ.Notification -= HandleNotification;
        }
    }
}