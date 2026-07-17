namespace MyTestProject.Events;

public class Task4
{
    public class Product(string name, decimal price)
    {
        public string Name { get; } = name;
        public decimal Price { get; private set; } = price;

        public event EventHandler<PriceChangedEventArgs>? PriceChanged;

        public void ChangePrice(decimal newPrice)
        {
            if (Price != newPrice)
            {
                PriceChangedEventArgs priceChangedEventArgs = new(Name, Price, newPrice);
                Price = newPrice;
                PriceChanged?.Invoke(this, priceChangedEventArgs);
            }
        }
    }

    public class PriceChangedEventArgs : EventArgs
    {
        public string Name { get; }
        public decimal OldPrice { get; }
        public decimal NewPrice { get; }
        public decimal? Percent { get; }

        public PriceChangedEventArgs(string name, decimal oldPrice, decimal newPrice)
        {
            Name = name;
            OldPrice = oldPrice;
            NewPrice = newPrice;
            Percent = (newPrice - oldPrice) / oldPrice * 100;
        }
    }
}