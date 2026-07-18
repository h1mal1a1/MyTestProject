namespace MyTestProject.Async;

public class Task1
{
    public async Task MyTask()
    {
        Console.WriteLine("Начало работы");
        Task ts = Task.Delay(2000);
        await ts;
        Console.WriteLine("Завершена первая операция");
        ts = Task.Delay(3000);
        await ts;
        Console.WriteLine("Завершена вторая операция");
        Console.WriteLine("Завершена работа");
    }
}