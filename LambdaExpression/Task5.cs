namespace MyTestProject.LambdaExpression;

public class Task5
{
    public Func<int> CreateCounter()
    {
        int counter = 0;
        return () => ++counter;
    }
}