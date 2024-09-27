using FirstLook.Handlers;

class UserProcessor
{
  public async Task<bool> Register(User user)
  {
    try
    {
      var handler = Handler<User>.CreateChain([
        new SocialSecurityNumberValidatorHandler(),
        new AgeValidationHandler(),
        new NameValidationHandler(),
        new CitizenshipRegionValidationHandler()
      ]);

      await handler.HandleAsync(user);

      return true;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return false;
    }
  }
}
