using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaleLearnCode.NewHorizons.DotNet8.Serialization;

public class CompanyInfo
{
	public required string Name { get; set; }
	public string? PhoneNumber { get; set; }
}

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
public class CustomerInfo
{

	// Both of these properties are read-only
	public List<string> Names { get; } = new();
	public CompanyInfo Company { get; } = new() { Name = "N/A", PhoneNumber = "N/A" };
}

public class ReadOnlyProperties
{
	public static void Demo()
	{
		CustomerInfo customer = JsonSerializer.Deserialize<CustomerInfo>("""{"Names":["John Doe"],"Company":{"Name":"Contoso"}}""")!;
		Console.WriteLine(JsonSerializer.Serialize(customer));
		// Prior to .NET 8: {"Names":[],"Company":{"Name":"N/A","PhoneNumber":"N/A"}}
		// Starting with .NET 8: {"Names":["John Doe"],"Company":{"Name":"Contoso","PhoneNumber":null}}
	}


}