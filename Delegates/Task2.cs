namespace MyTestProject.Delegates;

public class Task2
{
    public delegate string StringProcessor(string value);
    public string ProcessString(string value, StringProcessor processor) => processor(value);
}