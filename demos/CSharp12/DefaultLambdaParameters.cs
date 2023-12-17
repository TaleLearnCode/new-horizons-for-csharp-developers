namespace TaleLearnCode.NewHorizons.CSharp12;

public class DefaultLambdaParameters
{

	public void Examples()
	{

		// Specify zero input parameters with empty parentheses
		Action action = () => Console.WriteLine("Hello World");

		// If a lambda express has only one input parameter, the parentheses can be omitted
		Func<double, double> cube = x => x * x * x;

		// Two or more input parameters are separated by commas
		Func<int, int, bool> testForEquality = (x, y) => x == y;

		// Sometimes the compile cannot infer the types of input parameters; you can specify the types explicitly
		Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;

	}

	public void CSharp12Example1()
	{

		// Declare a lambda express with a default parameter, then call it once using the default and once with two explicit parameters
		static int IncrementBy(int source, int increment = 1) => source + increment;

		Console.WriteLine(IncrementBy(5)); // 6
		Console.WriteLine(IncrementBy(5, 2)); // 7

	}


	public void CSharp12Example2()
	{

		// You can also declare lambda expressions with params arrays as parameters

		static int sum(params int[] values)
		{
			int sum = 0;
			foreach (var value in values)
				sum += value;

			return sum;
		}

		var empty = sum();
		Console.WriteLine(empty); // 0

		var sequence = new[] { 1, 2, 3, 4, 5 };
		var total = sum(sequence);
		Console.WriteLine(total); // 15

	}

}