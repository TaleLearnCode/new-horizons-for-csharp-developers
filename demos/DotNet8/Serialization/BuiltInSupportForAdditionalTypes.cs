using System.Text.Json;

namespace TaleLearnCode.NewHorizons.DotNet8.Serialization;



public class BuiltInSupportForAdditionalTypes
{

	public Half Half { get; set; }
	public Int128 Int128 { get; set; }
	public UInt128 UInt128 { get; set; }

	public BuiltInSupportForAdditionalTypes()
	{
		Half = Half.MaxValue;
		Int128 = Int128.MaxValue;
		UInt128 = UInt128.MaxValue;
	}

	public static void Demo()
	{
		Console.WriteLine();
		Console.WriteLine("-------------------------------------");
		Console.WriteLine("Built-in Support for Additional Types");
		Console.WriteLine("-------------------------------------");
		Console.WriteLine();

		Console.WriteLine("Support for Half, Int128, and UInt128 types:");
		Console.WriteLine(JsonSerializer.Serialize(new BuiltInSupportForAdditionalTypes()));
		// [65500,170141183460469231731687303715884105727,340282366920938463463374607431768211455]

		Console.WriteLine();
		Console.WriteLine("Support for ReadOnlyMemory<byte>:");
		Console.WriteLine(JsonSerializer.Serialize<ReadOnlyMemory<byte>>(new byte[] { 1, 2, 3 })); // "AQID"

		Console.WriteLine();
		Console.WriteLine("Support for Memory<byte>:");
		Console.WriteLine(JsonSerializer.Serialize<Memory<int>>(new int[] { 1, 2, 3 })); // [1,2,3]

	}

}