using TaleLearnCode.NewHorizons.DotNet8.NewRandomMethods;
using TaleLearnCode.NewHorizons.DotNet8.PerformanceFocusedTypes;
using TaleLearnCode.NewHorizons.DotNet8.Serialization;

do
{
	Console.Clear();
	Console.WriteLine("Specify the demo to run:");
	Console.WriteLine("\t[1] Serialization - Handle Missing Members During Deserialization Demo 1");
	Console.WriteLine("\t[2] Serialization - Handle Missing Members During Deserialization Demo 2");
	Console.WriteLine("\t[3] Serialization - Built-in Support for Additional Types");
	Console.WriteLine("\t[4] Serialization - Interface Hierarchies");
	Console.WriteLine("\t[5] Serialization - Naming Policies");
	Console.WriteLine("\t[6] Serialization - ReadOnly Properties");
	Console.WriteLine("\t[7] Serialization - Non-Public Members");
	Console.WriteLine("\t[8] Serialization - Streaming deserialization APIs");
	Console.WriteLine("\t[9] New Random Methods - GetItems<T>()");
	Console.WriteLine("\t[10] New Random Methods - Shuffle<T>()");
	Console.WriteLine("\t[11] Performance-Focused Types - Frozen Collections");
	string? demoToRun = Console.ReadLine();
	if (demoToRun is not null)
	{
		try
		{
			if (demoToRun == "1")
				HandleMissingMembersDuringDeserialization.PocoAnnotated();
			else if (demoToRun == "2")
				HandleMissingMembersDuringDeserialization.PocoNotAnnotated();
			else if (demoToRun == "3")
				BuiltInSupportForAdditionalTypes.Demo();
			else if (demoToRun == "4")
				InterfaceHierarchies.Demo();
			else if (demoToRun == "5")
				NamingPolicies.Demo();
			else if (demoToRun == "6")
				ReadOnlyProperties.Demo();
			else if (demoToRun == "7")
				NonPublicMembers.Demo();
			else if (demoToRun == "8")
				await StreamingDeserializationAPIs.DemoAsync();
			else if (demoToRun == "9")
				GetItems.Demo();
			else if (demoToRun == "10")
				Shuffle.Demo();
			else if (demoToRun == "11")
				Frozen.Demo();
			else
				Console.WriteLine("Invalid selection.");
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ex.Message);
			Console.ResetColor();
		}
	}
	Console.WriteLine();
	Console.WriteLine("Press any key to continue...");
	Console.ReadKey(true);
} while (true);