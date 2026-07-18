namespace MyTestProject.Async;

public class Task10
{
    private static async Task First(SemaphoreSlim s1, SemaphoreSlim s2)
    {
        await s1.WaitAsync();
        Console.WriteLine("Первая операция захватила первый ресурс");
        await Task.Delay(1000);
        await s2.WaitAsync();
        Console.WriteLine("Первая операция заканчивает работу");
        s1.Release();
        s2.Release();
    }
    private static async Task Second(SemaphoreSlim s1, SemaphoreSlim s2)
    {
        await s2.WaitAsync();
        Console.WriteLine("Вторая операция захватила второй ресурс");
        await Task.Delay(1000);
        await s1.WaitAsync();
        Console.WriteLine("Вторая операция заканчивает работу");
        s1.Release();
        s2.Release();
    }
    public static async Task MainTask10()
    {
        SemaphoreSlim s1 = new(1);
        SemaphoreSlim s2 = new(1);
        await Task.WhenAll(First(s1, s2), Second(s1, s2));
    }
}