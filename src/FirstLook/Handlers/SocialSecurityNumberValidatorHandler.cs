
namespace FirstLook.Handlers;

class SocialSecurityNumberValidatorHandler : Handler<User>
{
  private readonly SocialSecurityNumberValidator _validator = new();

  public override async Task HandleAsync(User request)
  {
    if (_validator.Validate(request.SocialSecurityNumber, request.RegionInfo) is false)
    {
      throw new ArgumentException("Invalid social security number");
    }

    await base.HandleAsync(request);
  }
}