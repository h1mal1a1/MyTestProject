namespace MyTestProject.Delegates;

public class Task7
{
    public void LogToConsole(string message)
    {
        Console.WriteLine($"Log message to console: {message}");
    }

    public void LogToFile(string message)
    {
        Console.WriteLine($"Log message to file: {message}");
    }

    public void LogToMemory(string message)
    {
        Console.WriteLine($"Log message to memory: {message}");
    }

    public Action<string>? logger;
}