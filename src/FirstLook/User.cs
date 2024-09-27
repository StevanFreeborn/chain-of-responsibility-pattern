using System.Globalization;

class User(string name, string socialSecurityNumber, RegionInfo regionInfo, DateTimeOffset birthday)
{
  public string Name { get; set; } = name;
  public string SocialSecurityNumber { get; set; } = socialSecurityNumber;
  public RegionInfo RegionInfo { get; set; } = regionInfo;
  public DateTimeOffset BirthDate { get; set; } = birthday;
  public int Age => DateTimeOffset.Now.Year - BirthDate.Year;
}
