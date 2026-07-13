namespace MyTestProject.LambdaExpression;

public class Task8
{
    public Func<string, bool> CreateMinLemgthValidator(int minLength) => str => str.Length >= minLength;
    public Func<int, bool> CreateRangeValidator(int min, int max) => range => range >= min && range <= max;
}