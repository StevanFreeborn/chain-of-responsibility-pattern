namespace FirstLook.Handlers;

class CitizenshipRegionValidationHandler : Handler<User>
{
  public override async Task HandleAsync(User request)
  {
    if (request.RegionInfo.TwoLetterISORegionName == "NO")
    {
      throw new ArgumentException("Norwegian citizens are not allowed to register");
    }

    await base.HandleAsync(request);
  }
}