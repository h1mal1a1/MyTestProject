namespace MyTestProject.Async;

public class Task9
{
    private static async Task First(TaskCompletionSource firstSignal, TaskCompletionSource secondSignal)
    {
        Console.WriteLine("Start first task");
        firstSignal.SetResult();
        await secondSignal.Task;
        Console.WriteLine("End first task");
    }

    private static async Task Second(TaskCompletionSource firstSignal, TaskCompletionSource secondSignal)
    {
        Console.WriteLine("Start second task");
        await firstSignal.Task;
        secondSignal.SetResult();
        Console.WriteLine("End second task");
    }

    public static async Task MainTask9()
    {
        TaskCompletionSource signal1 = new();
        TaskCompletionSource signal2 = new();
        await Task.WhenAll([First(signal1, signal2), Second(signal1, signal2)]);
        Console.WriteLine("Программа завершена.");
    }
}