namespace MyTestProject.Patterns.StructuralPatterns.Adapter;

public class StripePaymentAdapter(StripeApi stripeApi) : IPaymentService
{
    private readonly StripeApi _stripeApi = stripeApi;

    public void Pay(decimal amount)
    {
        _stripeApi.MakePayment(amount);
    }
}