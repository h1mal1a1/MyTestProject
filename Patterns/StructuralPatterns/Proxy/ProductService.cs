namespace MyTestProject.Patterns.StructuralPatterns.Proxy;

public class ProductService : IProductService
{
    public string GetProductName(long productId)
    {
        Console.WriteLine("Loading product from database...");
        return $"Product {productId}";
    }
}