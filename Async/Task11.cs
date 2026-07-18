namespace MyTestProject.Async;

public class Task11
{
    private static async Task First(SemaphoreSlim s1, SemaphoreSlim s2)
    {
        await s1.WaitAsync();
        try
        {
            Console.WriteLine("Первая операция захватила первый ресурс");

            await Task.Delay(1000);

            await s2.WaitAsync();
            try
            {
                Console.WriteLine("Первая операция захватила второй ресурс");
                Console.WriteLine("Первая операция начинает работа с ресурсами");
                await Task.Delay(1000);
            }
            finally
            {
                s2.Release();
                Console.WriteLine("Первая операция освободила второй ресурс");
            }
        }
        finally
        {
            s1.Release();
            Console.WriteLine("Первая операция освободила первый ресурс");

        }
        Console.WriteLine("Первая операция заканчивает работу");
    }
    private static async Task Second(SemaphoreSlim s1, SemaphoreSlim s2)
    {
        await s1.WaitAsync();
        try
        {
            Console.WriteLine("Вторая операция захватила первый ресурс");
            await Task.Delay(1000);
            await s2.WaitAsync();

            try
            {
                Console.WriteLine("Вторая операция захватила второй ресурс");
                Console.WriteLine("Вторая операция начинает работа с ресурсами");
                await Task.Delay(1000);
            }
            finally
            {
                s2.Release();
                Console.WriteLine("Вторая операция освободила второй ресурс");
            }
        }
        finally
        {
            s1.Release();
            Console.WriteLine("Вторая операция освободила первый ресурс");
        }
        Console.WriteLine("Вторая операция заканчивает работу");
    }
    public static async Task MainTask11()
    {
        using SemaphoreSlim s1 = new(1);
        using SemaphoreSlim s2 = new(1);
        await Task.WhenAll(First(s1, s2), Second(s1, s2));
        Console.WriteLine("Программа завершена");
    }
}