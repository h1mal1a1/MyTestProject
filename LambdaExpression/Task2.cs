namespace MyTestProject.LambdaExpression;

public class Task2
{
    public class Product(string name, decimal price, int stock)
    {
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public int Stock { get; set; } = stock;
    }
}