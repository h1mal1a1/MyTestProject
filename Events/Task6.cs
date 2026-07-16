namespace MyTestProject.Events;

public class Task6
{
    public class NotificationPublisher
    {
        public event EventHandler? Notification;

        public void SendNotification()
        {
            Console.WriteLine("Отправка уведомления");
            Notification?.Invoke(this, EventArgs.Empty);
        }
    }

    public class NotificationSubscriber
    {
        public void HandleNotification(object? sender, EventArgs e)
        {
            Console.WriteLine("Подписчик получил уведомление.");
        }
    }
}