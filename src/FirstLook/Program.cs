using System.Globalization;

var processor = new UserProcessor();

var invalidResult = await processor.Register(new(
  name: "Stevan Freeborn",
  socialSecurityNumber: "00000000",
  regionInfo: new RegionInfo("NO"),
  birthday: new DateTimeOffset(1993, 04, 21, 00, 00, 00, TimeSpan.FromHours(-5))
));

var validResult = await processor.Register(new(
  name: "Stevan Freeborn",
  socialSecurityNumber: "00000000",
  regionInfo: new RegionInfo("US"),
  birthday: new DateTimeOffset(1993, 04, 21, 00, 00, 00, TimeSpan.FromHours(-5))
));

Console.WriteLine(invalidResult);
Console.WriteLine(validResult);
