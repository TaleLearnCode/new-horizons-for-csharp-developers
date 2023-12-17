
using Point = (int x, int y);

namespace TaleLearnCode.NewHorizons.CSharp12;

public class AliasAnyType
{

	public static void Run()
	{
		Point point = (1, 2);
		Console.WriteLine($"Point: {point.x}, {point.y}");
	}

}