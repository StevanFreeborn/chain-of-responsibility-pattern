namespace PaymentProcessor;

abstract class PaymentHandler : IHandler<Order>
{
  private IHandler<Order>? _nextHandler;

  public static IHandler<Order> CreateChain(IEnumerable<IHandler<Order>> handlers)
  {
    if (handlers is null)
    {
      throw new ArgumentNullException(nameof(handlers));
    }

    if (handlers.Any() is false)
    {
      throw new ArgumentException("At least one handler must be provided", nameof(handlers));
    }

    IHandler<Order>? root = null;
    IHandler<Order>? current = null;

    foreach (var handler in handlers)
    {
      if (root is null)
      {
        root = handler;
        current = handler;
      }

      if (current is not null)
      {
        current.SetNext(handler);
        current = handler;
      }
    }

    return root ?? throw new InvalidOperationException("Failed to create chain");
  }

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