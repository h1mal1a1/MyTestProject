using System.Diagnostics;

namespace MyTestProject.Async;

public class Task4
{
    private static async Task<string> First()
    {
        await Task.Delay(1000);
        return "First";
    }

    private static async Task<string> Second()
    {
        await Task.Delay(2000);
        throw new InvalidOperationException("MyError");
    }

    private static async Task<string> Third()
    {
        await Task.Delay(3000);
        return "Third";
    }

    public static async Task MainFunc()
    {
        Stopwatch sw = new();
        sw.Start();

        Task<string>[] tasks = [First(), Second(), Third()];

        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Во время выполнения задач произошла ошибка: {ex.Message}");
        }

        foreach (var task in tasks)
        {
            string msg = $"Status: {task.Status}. ";
            if (task.IsCompletedSuccessfully)
                msg += $"Result task: {task.Result}";
            else if (task.IsFaulted)
                msg += task.Exception!.GetBaseException().Message;
            else if (task.IsCanceled)
                msg += $"Task was canceled";
            Console.WriteLine(msg);

        }
        sw.Stop();
        Console.WriteLine($"Elapsed: {sw.Elapsed}");
    }
}