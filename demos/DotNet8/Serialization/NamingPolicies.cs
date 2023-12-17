using System.Text.Json;

namespace TaleLearnCode.NewHorizons.DotNet8.Serialization;

public class NamingPolicies
{

	public static void Demo()
	{

		Console.WriteLine();
		Console.WriteLine("------------------------");
		Console.WriteLine("Naming policies");
		Console.WriteLine("------------------------");

		Console.WriteLine();
		Console.WriteLine("No naming policy:");
		Console.WriteLine(JsonSerializer.Serialize(new { PropertyName = "value" }));

		Console.WriteLine();
		Console.WriteLine("CamelCase (existed prior to .NET 8):");
		Console.WriteLine(JsonSerializer.Serialize(new { PropertyName = "value" }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));

		Console.WriteLine();
		Console.WriteLine("SnakeCaseLower:");
		Console.WriteLine(JsonSerializer.Serialize(new { PropertyName = "value" }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower }));

		Console.WriteLine();
		Console.WriteLine("SnakeCaseUpper:");
		Console.WriteLine(JsonSerializer.Serialize(new { PropertyName = "value" }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper }));

		Console.WriteLine();
		Console.WriteLine("KebabCaseLower:");
		Console.WriteLine(JsonSerializer.Serialize(new { PropertyName = "value" }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower }));

		Console.WriteLine();
		Console.WriteLine("KebabCaseUpper:");
		Console.WriteLine(JsonSerializer.Serialize(new { PropertyName = "value" }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper }));

	}

}