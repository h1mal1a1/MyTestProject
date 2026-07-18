using System.Diagnostics;

namespace MyTestProject.Async;

public class Task2
{
    static async Task LocalTask2Async()
    {
        Console.WriteLine($"{DateTime.Now} Запущена вторая задача");
        await Task.Delay(3000);
        Console.WriteLine($"{DateTime.Now} Вторая задача завершена");
    }
    static async Task LocalTask1Async()
    {
        Console.WriteLine($"{DateTime.Now} Запущена первая задача");
        await Task.Delay(2000);
        Console.WriteLine($"{DateTime.Now} Первая задача завершена");
    }
    public async Task MyTask()
    {
        Stopwatch sw = new();
        sw.Start();
        Console.WriteLine($"{DateTime.Now} Начало работы");

        await Task.WhenAll([LocalTask1Async(), LocalTask2Async()]);

        Console.WriteLine($"{DateTime.Now} Конец работы");
        sw.Stop();
        Console.WriteLine($"{DateTime.Now} Elapsed time: {sw.Elapsed}");

    }
}