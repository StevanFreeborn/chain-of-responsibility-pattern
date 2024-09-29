namespace PaymentProcessor;

class Payment
{
  public decimal Amount { get; set; }
  public string? PaymentProvider { get; set; }
}

static class PaymentProvider
{
  public const string Invoice = "Invoice";
  public const string PayPal = "PayPal";
  public const string CreditCard = "CreditCard";
}