using System.Text.Json;

namespace TaleLearnCode.NewHorizons.DotNet8.Serialization;


public interface IBase
{
	public int Base { get; set; }
}

public interface IDerived : IBase
{
	public int Derived { get; set; }
}

public class DerivedImplement : IDerived
{
	public int Base { get; set; }
	public int Derived { get; set; }
}

public class InterfaceHierarchies
{

	public static void Demo()
	{
		Console.WriteLine();
		Console.WriteLine("------------------------");
		Console.WriteLine("Interface Hierarchies");
		Console.WriteLine("------------------------");
		Console.WriteLine();

		DerivedImplement derivedImplement = new()
		{
			Base = 42,
			Derived = 84
		};

		Console.WriteLine(JsonSerializer.Serialize(derivedImplement));

	}

}