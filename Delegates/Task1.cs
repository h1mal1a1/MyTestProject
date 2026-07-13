namespace MyTestProject.Delegates;

public class Task1
{
    public delegate int MathOperation(int a, int b);

    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    public int Calculate(int a, int b, MathOperation operation) => operation(a, b);
}