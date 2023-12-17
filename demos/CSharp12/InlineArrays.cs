namespace TaleLearnCode.NewHorizons.CSharp12;

// Example of an Inline Array
[System.Runtime.CompilerServices.InlineArray(10)]
public struct Buffer
{
	private int _element0;
}

public class InlineArrays
{

	// You use the inline array just like any other array; the difference is that the compiler
	// can take advantage of known information about an inline array.  You likely consume inline
	// as your would any other array.
	public void UsingInlineArrays()
	{

		var buffer = new Buffer();
		for (int i = 0; i < 10; i++)
		{
			buffer[i] = i;
		}

		foreach (var i in buffer)
		{
			Console.WriteLine(i);
		}
	}

}