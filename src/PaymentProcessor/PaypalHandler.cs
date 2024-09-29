
namespace PaymentProcessor;

class PaypalHandler : PaymentHandler
{
  private readonly PaypalPaymentProcessor _paypalPaymentProcessor = new();

  public override async Task HandleAsync(Order order)
  {
    if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.PayPal))
    {
      _paypalPaymentProcessor.Finalize(order);
    }

    await base.HandleAsync(order);
  }
}

class PaypalPaymentProcessor : IPaymentProcessor
{
  public void Finalize(Order order)
  {
    var payment = order.SelectedPayments.FirstOrDefault(p => p.PaymentProvider is PaymentProvider.PayPal);

    if (payment is null)
    {
      return;
    }

    order.FinalizedPayments.Add(payment);
  }
}