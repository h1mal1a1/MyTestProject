namespace MyTestProject.Patterns.StructuralPatterns.Proxy;
public class CachedProductServiceProxy(IProductService productService) : IProductService
{
    private readonly IProductService _productService = productService;
    private readonly Dictionary<long, string> _cache = [];

    public string GetProductName(long productId)
    {
        if (_cache.TryGetValue(productId, out string? cachedName))
        {
            Console.WriteLine("Loading product from cache...");
            return cachedName;
        }

        string name = _productService.GetProductName(productId);
        _cache[productId] = name;
        return name;
    }
}