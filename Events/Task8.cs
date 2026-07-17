namespace MyTestProject.Events;

public class Task8
{
    public class NotificationPublisher
    {
        public event EventHandler? Notification;

        public void SendNotification()
        {
            if (Notification is null)
            {
                return;
            }

            foreach (EventHandler handler in Notification.GetInvocationList())
            {
                try
                {
                    handler.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в обработчике: {handler.Method.Name}: {ex.Message}", ex);
                }
            }
        }
    }

    public class ConsoleNotification()
    {
        public void HandleNotification(object? sender, EventArgs e)
        {
            Console.WriteLine("Send notification to console");
        }
    }

    public class FileNotification(string pathToFile)
    {
        readonly string PathToFile = pathToFile;
        public void HandleNotification(object? sender, EventArgs e)
        {
            if (File.Exists(PathToFile))
                throw new Exception($"File ({PathToFile}) exists");
            File.WriteAllText(PathToFile, "Send notifi to console");
        }
    }
}