namespace MyTestProject.Events;

public class Task9
{
    public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs args) where TEventArgs : EventArgs;
    public class OrderService()
    {
        public event AsyncEventHandler<OrderCreatedEventArgs>? OrderCreated;

        public Task NotifyParallelAsync(OrderCreatedEventArgs orderCreatedEventArgs)
        {
            if (OrderCreated is null)
                return Task.CompletedTask;
            List<Task> tasks = [];
            foreach (Delegate deleg in OrderCreated.GetInvocationList())
            {
                var handler = (AsyncEventHandler<OrderCreatedEventArgs>)deleg;
                Task ts = handler.Invoke(this, orderCreatedEventArgs);
                tasks.Add(ts);
            }
            return Task.WhenAll(tasks);
        }

        public async Task NotifySequentialAsync(OrderCreatedEventArgs orderCreatedEventArgs)
        {
            if (OrderCreated is null)
                return;
            foreach (Delegate deleg in OrderCreated.GetInvocationList())
            {
                var handler = (AsyncEventHandler<OrderCreatedEventArgs>)deleg;
                await handler.Invoke(this, orderCreatedEventArgs);
            }
        }
    }

    public class OrderCreatedEventArgs(long id, string nameOrder) : EventArgs
    {
        public long Id { get; set; } = id;
        public string NameOrder { get; set; } = nameOrder;
    }

    public class EmailNotification
    {
        public async Task SendEmail(object sender, OrderCreatedEventArgs args)
        {
            string msg = $"{DateTime.Now}. Email: Order created: Id={args.Id}, OrderName={args.NameOrder}";
            await Task.Delay(1000);
            Console.WriteLine(msg);
        }
    }

    public class LoggerNotification
    {
        public async Task SendLogger(object sender, OrderCreatedEventArgs args)
        {
            string msg = $"{DateTime.Now}. Logger: Order created: Id={args.Id}, OrderName={args.NameOrder}";
            await Task.Delay(1000);
            Console.WriteLine(msg);
        }
    }

    public class AnalyticsNotification
    {
        public async Task SendAnalytic(object sender, OrderCreatedEventArgs args)
        {
            string msg = $"{DateTime.Now}. Analytics: Order created: Id={args.Id}, OrderName={args.NameOrder}";
            await Task.Delay(1000);
            Console.WriteLine(msg);
        }
    }
}