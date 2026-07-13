namespace MyTestProject.Patterns.StructuralPatterns.Facade;
public class OrderFacade(StockService stockService, PaymentService paymentService, EmailService emailService)
{
    private readonly StockService _stockService = stockService;
    private readonly PaymentService _paymentService = paymentService;
    private readonly EmailService _emailService = emailService;

    public void CreateOrder(long userId, long productId, decimal amount)
    {
        _stockService.Reserve(productId);
        _paymentService.Pay(userId, amount);
        _emailService.SendOrderConfirmation(userId);
    }
}