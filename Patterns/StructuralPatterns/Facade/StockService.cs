namespace MyTestProject.Patterns.StructuralPatterns.Facade;
public class StockService
{
    public void Reserve(long productId)
    {
        Console.WriteLine($"Reserve product {productId}");
    }
}