namespace MyTestProject.Async;

public class Runner
{
    private async Task RunTask1()
    {
        Task1 ts1 = new();
        await ts1.MyTask();
    }
    private async Task RunTask2()
    {
        Task2 ts = new();
        await ts.MyTask();
    }

    private async Task RunTask3()
    {
        await Task3.MainFunc();
    }

    private async Task RunTask4()
    {
        await Task4.MainFunc();
    }
    public async Task RunTasks()
    {
        await RunTask4();
    }
}