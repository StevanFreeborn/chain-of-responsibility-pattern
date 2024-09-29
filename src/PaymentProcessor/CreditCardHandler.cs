namespace PaymentProcessor;

class CreditCardHandler : PaymentHandler
{
  private readonly CreditCardPaymentProcessor _creditCardPaymentProcessor = new();

  public override async Task HandleAsync(Order order)
  {
    if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
    {
      _creditCardPaymentProcessor.Finalize(order);
    }

    await base.HandleAsync(order);
  }
}