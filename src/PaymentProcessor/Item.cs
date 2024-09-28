namespace PaymentProcessor;

class Item(
  string identifier,
  string name,
  decimal price,
  int quantity
)
{
  public string Identifier { get; set; } = identifier;
  public string Name { get; set; } = name;
  public decimal Price { get; set; } = price;
  public int Quantity { get; set; } = quantity;
}