namespace TaleLearnCode.NewHorizons.DotNet8.NewRandomMethods;

internal class ColorPrinting
{

	internal static void PrintColors(int round, ConsoleColor[] colors)
	{
		Console.Write($"Round {round}: ");
		for (int i = 0; i < colors.Length; i++)
		{
			PrintColor(colors[i]);
			if (i < colors.Length - 1)
				Console.Write(", ");
		}
	}

	private static void PrintColor(ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.Write(color);
		Console.ResetColor();
	}

}