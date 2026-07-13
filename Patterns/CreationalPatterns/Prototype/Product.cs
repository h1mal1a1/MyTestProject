namespace MyTestProject.Patterns.CreationalPatterns.Prototype;
public class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<string> Tags {get;set;} = [];

    public Product Clone()
    {
        return new Product
        {
            Name = Name,
            Price = Price,
            Tags = [.. Tags]
        };
    }
}