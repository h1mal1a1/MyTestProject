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


    }



    public static void RunTest4()
    {

    }
    public static void RunTest5()
    {

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
        RunTest2();
    }
}