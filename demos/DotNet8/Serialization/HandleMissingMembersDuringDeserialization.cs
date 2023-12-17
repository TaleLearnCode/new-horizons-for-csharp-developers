using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaleLearnCode.NewHorizons.DotNet8.Serialization;

[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
public class MyPoco
{
	public int Id { get; set; }
}

public class MyOtherPoco
{
	public int Id { get; set; }
}

public class HandleMissingMembersDuringDeserialization
{
	public static void PocoAnnotated()
	{
		// JsonException : The JSON property 'AnotherId' could not be mapped to any .NET member contained in type 'MyPoco'.
		MyPoco? poco = JsonSerializer.Deserialize<MyPoco>("""{"Id" : 42, "AnotherId" : -1 }""");
		if (poco is not null)
			Console.WriteLine("Id: {0}", poco.Id);
	}

	public static void PocoNotAnnotated()
	{
		JsonSerializerOptions jsonSerializerOptions = new()
		{
			UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
		};
		MyOtherPoco? poco = JsonSerializer.Deserialize<MyOtherPoco>("""{"Id" : 42, "AnotherId" : -1 }""", jsonSerializerOptions);
		if (poco is not null)
			Console.WriteLine("Id: {0}", poco.Id);
	}

}