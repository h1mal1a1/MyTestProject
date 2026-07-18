using System.Diagnostics;

namespace MyTestProject.Async;

public class Task5
{
    private static async Task<string> First()
    {
        await Task.Delay(1000);
        throw new InvalidOperationException("MyInvalidOperationException");
    }

    private static async Task<string> Second()
    {
        await Task.Delay(2000);
        throw new ArgumentException("MyArgumentException");
    }

    private static async Task<string> Third()
    {
        await Task.Delay(3000);
        return "Third";
    }

    public static async Task MainTask5()
    {
        Stopwatch sw = new();
        sw.Start();
        Task<string>[] tasks = [First(), Second(), Third()];
        Task<string[]> mainTask = Task.WhenAll(tasks);
        try
        {
            await mainTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"При выполнении задач произошла ошибка.\r\nТип ошибки: {ex.GetType().Name}.\r\n" +
                $"Сообщение: {ex.Message}");
        }
        Console.WriteLine();
        if (mainTask.Exception is not null)
        {
            foreach (Exception exc in mainTask.Exception.InnerExceptions)
            {
                Console.WriteLine($"Тип: {exc.GetType().Name}");
                Console.WriteLine($"Ошибка: {exc.Message}");
            }
        }
        Console.WriteLine();
        foreach (var task in tasks)
        {
            if (task.IsCompletedSuccessfully)
            {
                Console.WriteLine($"Задача: {task.Id}, выполнилась успешно. Результат: {task.Result}");
            }
            else if (task.IsCanceled)
            {
                Console.WriteLine($"Задача: {task.Id} была отменена");
            }
            else if (task.IsFaulted)
            {
                Exception exc = task.Exception!.GetBaseException();
                var err = $"Задача: {task.Id} была заверешна с ошибкой:\r\nТип: {exc.GetType().Name}.\r\n";
                err += $"Ошибка: {exc.Message}";
                Console.WriteLine(err);
            }
        }

        sw.Stop();
        Console.WriteLine($"Время выполнения: {sw.Elapsed}");

    }
}