
namespace FirstLook.Handlers;

abstract class Handler<T> : IHandler<T> where T : class
{
  private IHandler<T>? _nextHandler;

  public static IHandler<T> CreateChain(IEnumerable<IHandler<T>> handlers)
  {
    if (handlers is null)
    {
      throw new ArgumentNullException(nameof(handlers));
    }

    if (!handlers.Any())
    {
      throw new ArgumentException("At least one handler must be provided", nameof(handlers));
    }

    IHandler<T>? root = null;
    IHandler<T>? current = null;

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

  public virtual async Task HandleAsync(T request)
  {
    if (_nextHandler is not null)
    {
      await _nextHandler.HandleAsync(request);
    }
  }

  public IHandler<T> SetNext(IHandler<T> handler)
  {
    _nextHandler = handler;
    return _nextHandler;
  }
}