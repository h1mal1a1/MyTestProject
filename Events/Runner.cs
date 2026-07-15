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

    }
    public static void RunTest7()
    {

    }
    public static void RunTest8()
    {

    }
    public static void RunTest9()
    {

    }
    public static void RunTest10()
    {



    }

    public static void RunAllTests()
    {
        RunTest5();
    }
}