namespace PaymentProcessor;

class InvoiceHandler : PaymentHandler
{
  private readonly InvoicePaymentProcessor _invoicePaymentProcessor = new();

  public override async Task HandleAsync(Order order)
  {
    if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
    {
      _invoicePaymentProcessor.Finalize(order);
    }

    await base.HandleAsync(order);
  }
}