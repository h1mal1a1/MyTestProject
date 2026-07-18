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

    private async Task RunTask5()
    {
        await Task5.MainTask5();
    }

    private async Task RunTask6()
    {
        await Task6.MainTask6();
    }

    private async Task RunTask7()
    {
        await Task7.MainTask7();
    }

    private async Task RunTask8()
    {
        await Task8.MainTask8();
    }
    private async Task RunTask9()
    {
        await Task9.MainTask9();
    }
    private async Task RunTask10()
    {
        await Task10.MainTask10();
    }

    private async Task RunTask11()
    {
        await Task11.MainTask11();
    }
    private async Task RunTask12()
    {
        await Task12.MainTask12();
    }

    private async Task RunTask13()
    {
        await Task13.MainTask13();
    }

    public async Task RunTasks()
    {
        await RunTask12();
    }
}