namespace MyTestProject.Delegates;

public class Task6
{
    public void ForEach<T>(IEnumerable<T> items, Action<T> action)
    {
        foreach(var item in items)
            action(item);
    }
}