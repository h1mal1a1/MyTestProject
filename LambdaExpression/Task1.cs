namespace MyTestProject.LambdaExpression;

public class Task1
{
    public delegate int MathOperation(int a, int b);

    public int Calculate(int a, int b, MathOperation operation) => operation(a, b);
}