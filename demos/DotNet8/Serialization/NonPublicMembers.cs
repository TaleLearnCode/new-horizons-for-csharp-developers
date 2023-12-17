using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaleLearnCode.NewHorizons.DotNet8.Serialization;

public class NonPublicMembersPoco
{

	[JsonConstructor]
	internal NonPublicMembersPoco(int x) => X = x;

	[JsonInclude]
	internal int X { get; set; }

}

public class NonPublicMembers
{
	public static void Demo()
	{
		Console.WriteLine(JsonSerializer.Serialize(new NonPublicMembersPoco(42)));
	}
}