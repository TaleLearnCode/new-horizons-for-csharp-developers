namespace TaleLearnCode.NewHorizons.CSharp12;

public class RefReadonly
{

	public static void ForceByRef(ref readonly OptionStruct thing)
	{
		// Logic goes here
	}

	public void TestForceByRef()
	{
		OptionStruct options = new(1, 2);

		ForceByRef(in options);
		ForceByRef(ref options);
		ForceByRef(options);  // Warning! variable should be passed with 'ref' or 'in' keyword
		ForceByRef(new OptionStruct());  // Warning, but an expression, so no variable to reference
	}

}

public struct OptionStruct
{
	public int Option1 { get; set; }
	public int Option2 { get; set; }
	public OptionStruct(int option1, int option2)
	{
		Option1 = option1;
		Option2 = option2;
	}
}