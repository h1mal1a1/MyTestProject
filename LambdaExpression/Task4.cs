namespace MyTestProject.LambdaExpression;

public class Task4
{
    public class UserDto(string name, bool IsAdult)
    {
        public string Name { get; set; } = name;
        public bool IsAdult { get; set; } = IsAdult;
    }
}