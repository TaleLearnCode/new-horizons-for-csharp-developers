namespace TaleLearnCode.NewHorizons.CSharp12;

public class CollectionExpressions
{

	public void CollectionExpressionExamples()
	{

		// Create an array
		int[] a = [1, 2, 3, 4, 5, 6, 7, 8];

		// Create a list
		List<string> b = ["one", "two", "three", "four", "five"];

		// Create a span
		Span<char> c = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];

		// Create a jagged 2D array
		int[][] twoD = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

		// Create a jagged 2D array from variables
		int[] row1 = [1, 2, 3];
		int[] row2 = [4, 5, 6];
		int[] row3 = [7, 8, 9];
		int[][] twoDFromVariables = [row1, row2, row3];

	}

	public void CollectionExpressionUsingSpreadOperator()
	{
		int[] row0 = [1, 2, 3];
		int[] row1 = [4, 5, 6];
		int[] row2 = [7, 8, 9];
		int[] single = [.. row0, .. row1, .. row2];

		foreach (var element in single)
		{
			Console.Write($"{element}, ");
		}
		// output: 1, 2, 3, 4, 5, 6, 7, 8, 9,

	}

}