using System.Diagnostics;

namespace MyTestProject.Async;

public class Task6
{
    private static async Task ImitationOfReality(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(1000, cancellationToken);
            Console.WriteLine($"Шаг: {i + 1}");
        }
    }

    public static async Task MainTask6()
    {
        Stopwatch sw = new();
        sw.Start();
        using CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        Task task = ImitationOfReality(cancellationToken);
        await Task.Delay(3500);
        cancellationTokenSource.Cancel();
        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Операция отменена");
        }
        sw.Stop();
        Console.WriteLine($"Status: {task.Status}");
        Console.WriteLine($"Elapsed: {sw.Elapsed}");



    }
}