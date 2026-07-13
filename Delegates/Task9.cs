namespace MyTestProject.Delegates;

public class Task9
{
    public T ExecutePipeline<T>(T value, IEnumerable<Func<T,T>> operations)
    {
        T result = value;
        foreach(var op in operations)
            result = op(result);
        return result;
    }
}