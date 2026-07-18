using System.Diagnostics;

namespace MyTestProject.Async;

public class Task7
{
    private static async Task<string> ImitationOfReality(CancellationToken cancellationToken)
    {
        Console.WriteLine("Загружаю данные...");
        await Task.Delay(5000, cancellationToken);
        return "Данные загружены";
    }
    public static async Task MainTask7()
    {
        Stopwatch sw = new();
        sw.Start();
        using CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        Task<string> loadingTask = ImitationOfReality(cancellationToken);
        Task delayTask = Task.Delay(2000);
        var firstEndTask = await Task.WhenAny(loadingTask, delayTask);
        Console.WriteLine($"First task end with Id={firstEndTask.Id}. Status: {firstEndTask.Status}");

        if (firstEndTask == loadingTask)
        {
            Console.WriteLine(loadingTask.Result);
        }
        else if (firstEndTask == delayTask)
        {
            Console.WriteLine("Превышено время ожидания");
            cancellationTokenSource.Cancel();
            try
            {
                await loadingTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция загрузки данных отменена");
            }
            Console.WriteLine($"Статус задачи загрузки данных: {loadingTask.Status}");
        }



        sw.Stop();
        Console.WriteLine($"Затраченное время: {sw.Elapsed}");

    }
}