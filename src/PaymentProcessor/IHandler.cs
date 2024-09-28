namespace PaymentProcessor;

interface IHandler<T> where T : class
{
  IHandler<T> SetNext(IHandler<T> handler);
  Task HandleAsync(T request);
}