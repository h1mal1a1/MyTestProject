namespace MyTestProject.Async;

public class Task13
{
    private static async Task<string> SourceMethod()
    {
        Console.WriteLine("Source Method start");
        await Task.Delay(2000);
        Console.WriteLine("Source Method message");
        return "result";
    }
    public static async Task LambdaFunction()
    {
        Task<string> sourcetask = SourceMethod();
        string result = await sourcetask;
        Console.WriteLine(result);
    }
    public static async Task MainTask13()
    {
        ConcurrentExclusiveSchedulerPair schedulerPair = new(TaskScheduler.Default, 1);
        TaskScheduler exShed = schedulerPair.ExclusiveScheduler;
        Task<Task> task = Task.Factory.StartNew(
            async () => await LambdaFunction(),
            CancellationToken.None,
            TaskCreationOptions.None,
            exShed);
        await task.Unwrap();

    }
}