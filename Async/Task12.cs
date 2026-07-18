namespace MyTestProject.Async;

public class Task12
{
    private static async Task<string> SourceMethod()
    {
        Console.WriteLine("Source Method start");
        await Task.Delay(2000);
        Console.WriteLine("Source Method message");
        return "result";
    }

    public static async Task MainTask12()
    {
        ConcurrentExclusiveSchedulerPair schedulerPair = new(TaskScheduler.Default, 1);
        TaskScheduler exShed = schedulerPair.ExclusiveScheduler;
        Task task = Task.Factory.StartNew(
            () =>
            {
                Task<string> sourcetask = SourceMethod();
                string result = sourcetask.Result;
                Console.WriteLine(result);
            },
            CancellationToken.None,
            TaskCreationOptions.None,
            exShed);
        await task;

    }
}


/*
Этот код намернно зависнет.
Произойдет следующее:
1.Синхронная лямбда запускается на exShed.
2.SourceMethod доходит до await Task.Delay(2000);
3.Метод возвращет незавершенный Task<string>
4.Лямбда вызывает sourcetask.Result
5.Единственный исполнитель планировщика блокируется. Блокируется не обязательно один конкретный физический поток планировщика. 
Блокируется выполняемая работа, которая занимает единственное разрешенное место в ExclusiveScheduler
6.Через две секунды продолжение SourceMethod пытается вернуться в тот же планировщик.
7.Планировщик занят кодом, который ждет завершения SourceMethod.
8.Возникает deadlock.

*/