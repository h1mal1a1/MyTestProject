using System.Diagnostics;

namespace MyTestProject.Async;

public class Task3
{
    private static async Task<string> First()
    {
        await Task.Delay(2000);
        return "First";
    }

    private static async Task<string> Second()
    {
        await Task.Delay(3000);
        return "Second";
    }

    private static async Task<string> Third()
    {
        await Task.Delay(1000);
        return "Third";
    }

    public static async Task MainFunc()
    {
        Stopwatch sw = new();
        sw.Start();
        var res1 = First();
        var res2 = Second();
        var res3 = Third();
        Task<string>[] tasks = [res1, res2, res3];
        string[] results = await Task.WhenAll(tasks);

        Console.WriteLine(results[0]);
        Console.WriteLine(results[1]);
        Console.WriteLine(results[2]);
        sw.Stop();
        Console.WriteLine($"Elapsed: {sw.Elapsed}");
    }
}