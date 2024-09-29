namespace PaymentProcessor;

class CreditCardPaymentProcessor : IPaymentProcessor
{
  public void Finalize(Order order)
  {
    var payment = order.SelectedPayments.FirstOrDefault(p => p.PaymentProvider is PaymentProvider.CreditCard);

    if (payment is null)
    {
      return;
    }

    order.FinalizedPayments.Add(payment);
  }
}