using System.Diagnostics;

namespace MyTestProject.Events;

public class Runner
{
    public static void RunTest1()
    {
        Task1.TemperatureSensor task = new();
        task.TemperatureChanged += temp => Console.WriteLine($"Температура {temp}");
        task.TemperatureChanged += temp =>
        {
            if (temp > 30)
                Console.WriteLine("Осторожно температура выше 30");

        };
        task.TemperatureChanged += temp =>
        {
            if (temp < 0)
                Console.WriteLine("Осторожно температура ниже 0");
        };

        task.SetTemperature(32);
    }
    public static void RunTest2()
    {
        Task2.TemperatureSensor task = new();

        task.TemperatureChanged += (next) =>
        {
            Console.WriteLine($"Температура изменилась: {next}");
        };
        task.TemperatureChanged += temp =>
        {
            if (temp > 30)
                Console.WriteLine("Осторожно температура выше 30");

        };
        task.TemperatureChanged += temp =>
        {
            if (temp < 0)
                Console.WriteLine("Осторожно температура ниже 0");
        };

        task.SetTemperature(32);
        task.SetTemperature(32);
        task.SetTemperature(15);
    }
    public static void RunTest3()
    {
        Task3.TemperatureSensor sensor = new();

        sensor.TemperatureChanged += (_, e) =>
        {
            if (e.OldTemperature == null)
                Console.WriteLine($"Установлена начальная температура {e.NewTemperature}");
            else
                Console.WriteLine($"Температура изменилась c {e.OldTemperature} на {e.NewTemperature}");
        };
        sensor.SetTemperature(10);
        sensor.SetTemperature(10);
        sensor.SetTemperature(20);
    }
    public static void RunTest4()
    {
        Task4.Product product = new("Pr1", 1000);
        product.PriceChanged += (_, e) =>
        {
            Console.WriteLine($"Для продукта {e.Name} изменилась цена с {e.OldPrice} на {e.NewPrice}. Процент: {e.Percent}%");
        };
        product.ChangePrice(2000);
        product.ChangePrice(2000);
        product.ChangePrice(100);
    }
    public static void RunTest5()
    {
        Task5.Order order = new(5, "FirstOrder");
        order.StatusChanged += (_, e) =>
        {
            Console.WriteLine($"У заказа {e.Name} c Id={e.Id} изменился статус на {e.NewStatus}");
        };

        Task5.SmsNotification smsNotification = new();
        order.StatusChanged += smsNotification.HandleStatusChanged;

        Task5.EmailNotification emailNotification = new();
        order.StatusChanged += emailNotification.HandleStatusChanged;


        Task5.Logger logger = new();
        order.StatusChanged += logger.HandleStatusChanged;

        Task5.Analytics analytics = new();
        order.StatusChanged += analytics.HandleStatusChanged;

        order.ChangeStatus(Task5.OrderStatus.Paid);
    }
    public static void RunTest6()
    {
        Task6.NotificationPublisher publisher = new();
        Task6.NotificationSubscriber subscriber = new();
        publisher.Notification += subscriber.HandleNotification;
        publisher.SendNotification();
        publisher.Notification -= subscriber.HandleNotification;
        publisher.SendNotification();
    }
    public static void RunTest7()
    {
        Task7.Publisher publisher = new();

        using (var subscriber = new Task7.Subscriber(publisher))
        {
            Console.WriteLine("First calling");
            publisher.SendNotification();
        }

        Console.WriteLine("Second calling");
        publisher.SendNotification();

        /*
        1.Почему GC не может удалить подписчика?
        Потому что событие долгоживущего издателя хранит делегат обработчика, 
        а делегат хранит сильную ссылку на объект подписчика. 
        Поэтому подписчик остаётся достижимым и не считается мусором.

        2.Кто хранит ссылку на подписчика.
        Делегат, находящийся в событии издателя.

        3.Почему необходимо отписываться?
        Чтобы разорвать ссылку от события издателя к подписчику. 
        После этого, если других ссылок нет, подписчик становится доступным для сборки мусора.

        4.Где можно реализовать IDisposable?
        В классе подписчика. В его методе Dispose() выполняется отписка от события издателя.
        
        */
    }
    public static void RunTest8()
    {
        File.Create(Path.Combine(AppContext.BaseDirectory, "test.txt"));

        Task8.NotificationPublisher publisher = new();
        Task8.FileNotification fileNotifiocation = new(Path.Combine(AppContext.BaseDirectory, "test.txt"));
        Task8.ConsoleNotification consoleNotifion = new();
        publisher.Notification += fileNotifiocation.HandleNotification;
        publisher.Notification += consoleNotifion.HandleNotification;
        publisher.SendNotification();

    }
    public static async Task RunTest9()
    {
        Task9.EmailNotification emailNotification = new();
        Task9.AnalyticsNotification analyticsNotification = new();
        Task9.LoggerNotification loggerNotification = new();
        Task9.OrderService orderService = new();
        orderService.OrderCreated += emailNotification.SendEmail;
        orderService.OrderCreated += analyticsNotification.SendAnalytic;
        orderService.OrderCreated += loggerNotification.SendLogger;

        Task9.OrderCreatedEventArgs args = new(111, "FirstOrder");
        await orderService.NotifyParallelAsync(args);
        await orderService.NotifySequentialAsync(args);
    }
    public static void RunTest10()
    {



    }

    public async static Task RunAllTests()
    {
        await RunTest9();
    }
}