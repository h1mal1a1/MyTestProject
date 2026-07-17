namespace MyTestProject.Events;

public class Task5
{
    public enum OrderStatus
    {
        Created,
        Paid,
        Processing,
        Shipped,
        Completed,
        Canceled
    }

    public class Order(long id, string name)
    {
        public long Id { get; } = id;
        public string Name { get; } = name;

        public OrderStatus Status { get; private set; } = OrderStatus.Created;
        public event EventHandler<OrderStatusChangedEventArgs>? StatusChanged;
        public void ChangeStatus(OrderStatus newStatus)
        {
            if (Status != newStatus)
            {
                OrderStatusChangedEventArgs orderStatusesChangedEventArgs = new(Id, Name, newStatus);
                Status = newStatus;
                StatusChanged?.Invoke(this, orderStatusesChangedEventArgs);
            }
        }
    }

    public class OrderStatusChangedEventArgs(long id, string name, OrderStatus newStatus) : EventArgs
    {
        public long Id { get; } = id;
        public string Name { get; } = name;
        public OrderStatus NewStatus { get; } = newStatus;
    }

    public interface ISendNotification
    {
        void SendNotification(string notification);
    }

    public class EmailNotification : ISendNotification
    {
        public void HandleStatusChanged(object? sender, OrderStatusChangedEventArgs e)
        {
            SendNotification($"Статус заказа {e.Id},{e.Name} изменился: {e.NewStatus}");
        }

        public void SendNotification(string notification)
        {
            Console.WriteLine($"Email send: {notification}");
        }
    }

    public class SmsNotification : ISendNotification
    {
        public void HandleStatusChanged(object? sender, OrderStatusChangedEventArgs e)
        {
            SendNotification($"Статус заказа {e.Id},{e.Name} изменился: {e.NewStatus}");
        }
        public void SendNotification(string notification)
        {
            Console.WriteLine($"SMS notification: {notification}");
        }
    }

    public class Logger
    {
        public void HandleStatusChanged(object? sender, OrderStatusChangedEventArgs e)
        {
            Console.WriteLine($"Статус заказа {e.Id},{e.Name} изменился. Отправляю log-сообщение");
        }
    }

    public class Analytics
    {
        public void HandleStatusChanged(object? sender, OrderStatusChangedEventArgs e)
        {
            Console.WriteLine($"Статус заказа {e.Id},{e.Name} изменился. Продолжаю вести аналитику.");
        }
    }
}