namespace FirstLook.Handlers;

class AgeValidationHandler : Handler<User>
{
  public override async Task HandleAsync(User request)
  {
    if (request.Age < 18)
    {
      throw new ArgumentException("User must be at least 18 years old");
    }

    await base.HandleAsync(request);
  }
}