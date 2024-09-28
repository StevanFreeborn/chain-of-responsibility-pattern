namespace PaymentProcessor;

class Order
{
  public List<Payment> SelectedPayments { get; set; } = [];
  public List<Payment> FinalizedPayments { get; set; } = [];
  public List<Item> LineItems { get; set; } = [];
  public decimal AmountDue => LineItems.Sum(i => i.Price * i.Quantity) - FinalizedPayments.Sum(p => p.Amount);
  public string ShipStatus { get; set; } = ShippingStatus.WaitingForPayment;
}

static class ShippingStatus
{
  public const string WaitingForPayment = "WaitingForPayment";
  public const string ReadyForShipment = "ReadyForShipment";
  public const string Shipped = "Shipped";
}
