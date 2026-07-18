namespace MyTestProject.Async;

public class Task8
{
    private static async Task First(TaskCompletionSource firstSignal, TaskCompletionSource secondSignal)
    {
        Console.WriteLine("Start first task");
        await secondSignal.Task;
        firstSignal.SetResult();
        Console.WriteLine("End first task");
    }

    private static async Task Second(TaskCompletionSource firstSignal, TaskCompletionSource secondSignal)
    {
        Console.WriteLine("Start second task");
        await firstSignal.Task;
        secondSignal.SetResult();
        Console.WriteLine("End second task");
    }

    public static async Task MainTask8()
    {
        TaskCompletionSource signalFromFirst = new();
        TaskCompletionSource signalFromSecond = new();

        Task firstTask = First(signalFromFirst, signalFromSecond);
        Task secondTask = Second(signalFromFirst, signalFromSecond);
        await Task.WhenAll([firstTask, secondTask]);
    }
}