namespace PaymentProcessor;

abstract class PaymentHandler : IHandler<Order>
{
  private IHandler<Order>? _nextHandler;

  public IHandler<Order> SetNext(IHandler<Order> handler)
  {
    _nextHandler = handler;
    return _nextHandler;
  }

  public virtual async Task HandleAsync(Order order)
  {
    if (_nextHandler is null && order.AmountDue > 0)
    {
      throw new InvalidOperationException("Insufficient payment");
    }

    if (_nextHandler is not null && order.AmountDue > 0)
    {
      await _nextHandler.HandleAsync(order);
      return;
    }

    order.ShipStatus = ShippingStatus.ReadyForShipment;
  }
}