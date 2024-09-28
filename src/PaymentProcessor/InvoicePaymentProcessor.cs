namespace PaymentProcessor;

class InvoicePaymentProcessor : IPaymentProcessor
{
  public void Finalize(Order order)
  {
    var payment = order.SelectedPayments.FirstOrDefault(p => p.PaymentProvider is PaymentProvider.Invoice);

    if (payment is null)
    {
      return;
    }

    order.FinalizedPayments.Add(payment);
  }
}