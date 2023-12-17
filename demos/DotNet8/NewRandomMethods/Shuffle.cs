namespace TaleLearnCode.NewHorizons.DotNet8.NewRandomMethods;

public class Shuffle
{

	private static ConsoleColor[] LoadTrainingData()
	{
		return [
			ConsoleColor.Black,
			ConsoleColor.DarkBlue,
			ConsoleColor.DarkGreen,
			ConsoleColor.DarkCyan,
			ConsoleColor.DarkRed,
			ConsoleColor.DarkMagenta,
			ConsoleColor.DarkYellow,
			ConsoleColor.Gray,
			ConsoleColor.DarkGray,
			ConsoleColor.Blue,
			ConsoleColor.Green,
			ConsoleColor.Cyan,
			ConsoleColor.Red,
			ConsoleColor.Magenta,
			ConsoleColor.Yellow,
			ConsoleColor.White
		];
	}

	public static void Demo()
	{

		Console.WriteLine();
		Console.WriteLine("------------------------------------");
		Console.WriteLine("New Random Methods - Shuffle<T>()");
		Console.WriteLine("------------------------------------");

		ConsoleColor[] trainingData = LoadTrainingData();

		for (int round = 1; round <= 5; round++)
		{
			Console.WriteLine();
			Random.Shared.Shuffle(trainingData);
			ColorPrinting.PrintColors(round, trainingData);
			Console.WriteLine();
		}

	}


}