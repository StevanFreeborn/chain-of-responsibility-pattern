using PaymentProcessor;

var order = new Order();
order.LineItems.Add(new Item("Identifier", "Name", 100, 1));
order.LineItems.Add(new Item("Identifier", "Name", 100, 1));

order.SelectedPayments.Add(new Payment()
{
  PaymentProvider = PaymentProvider.PayPal,
  Amount = 100,
});
order.SelectedPayments.Add(new Payment()
{
  PaymentProvider = PaymentProvider.Invoice,
  Amount = 100,
});

Console.WriteLine(order.AmountDue);
Console.WriteLine(order.ShipStatus);

var rootHandler = PaymentHandler.CreateChain([
  new PaypalHandler(),
  new CreditCardHandler(),
  new InvoiceHandler()
]);

await rootHandler.HandleAsync(order);

Console.WriteLine(order.AmountDue);
Console.WriteLine(order.ShipStatus);