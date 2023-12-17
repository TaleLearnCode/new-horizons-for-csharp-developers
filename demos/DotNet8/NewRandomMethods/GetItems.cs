namespace TaleLearnCode.NewHorizons.DotNet8.NewRandomMethods;

public class GetItems
{

	public static void Demo()
	{

		Console.WriteLine();
		Console.WriteLine("------------------------------------");
		Console.WriteLine("New Random Methods - GetItems<T>()");
		Console.WriteLine("------------------------------------");

		ReadOnlySpan<ConsoleColor> allButtons =
		[
				ConsoleColor.Red,
						ConsoleColor.Green,
						ConsoleColor.Blue,
						ConsoleColor.Yellow,
				];

		Demo1(allButtons);
		Demo2(allButtons);
		Console.WriteLine();
	}

	private static void Demo1(ReadOnlySpan<ConsoleColor> allButtons)
	{
		Console.WriteLine();
		Console.WriteLine("Demonstration 1");
		for (int round = 1; round <= 5; round++)
		{
			Console.WriteLine();
			ConsoleColor[] thisRound = Random.Shared.GetItems(allButtons, round);
			ColorPrinting.PrintColors(round, thisRound);
		}
		Console.WriteLine();
	}

	private static void Demo2(ReadOnlySpan<ConsoleColor> allButtons)
	{
		Console.WriteLine();
		Console.WriteLine("Demonstration 2");
		List<ConsoleColor> allRounds = [];
		for (int round = 1; round <= 5; round++)
		{
			Console.WriteLine();
			allRounds.Add(Random.Shared.GetItems(allButtons, 1)[0]);
			ColorPrinting.PrintColors(round, allRounds.ToArray());
		}
	}

}