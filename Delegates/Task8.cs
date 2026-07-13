namespace MyTestProject.Delegates;

public class Task8
{
    public int AddOne(int value)
    {
        return value+1;
    }

    public int MultiplyByTwo(int value)
    {
        return value*2;
    }

    public int Square(int value)
    {
        return value*value;
    }

    public Func<int, int>? operation;
}