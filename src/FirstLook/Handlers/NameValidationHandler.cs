namespace FirstLook.Handlers;

class NameValidationHandler : Handler<User>
{
  public override async Task HandleAsync(User request)
  {
    if (request.Name.Length <= 1)
    {
      throw new ArgumentException("Name must be at least 2 characters long");
    }

    await base.HandleAsync(request);
  }
}