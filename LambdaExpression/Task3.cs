namespace MyTestProject.LambdaExpression;

public class Task3
{
    public class User(string name, int age, bool isActive, string role)
    {
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
        public bool IsActive { get; set; } = isActive;
        public string Role { get; set; } = role;
    }
}