namespace PaymentProcessor;

interface IPaymentProcessor
{
  void Finalize(Order order);
}
