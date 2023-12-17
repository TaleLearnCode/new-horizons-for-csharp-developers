using System.Diagnostics.CodeAnalysis;

namespace TaleLearnCode.NewHorizons.CSharp12;

[Experimental("TLC242")]
public class ExperimentalClass
{

	public static void ExperimentalMethod() => Console.WriteLine("I'm an experimental method!");

	public static void ExperimentalMethod2() => Console.WriteLine("I'm also an experimental method!");

}

public class ClassWithExperimentalCode
{

	public static void NonExperimentalMethod() => Console.WriteLine("I'm a non-experimental method!");

	[Experimental("TLC242")]
	public static void ExperimentalMethod() => Console.WriteLine("I'm an experimental method!");
}

public class UsingExperimentalCode
{

	public void Run()
	{

		//ExperimentalClass.ExperimentalMethod();
		//ExperimentalClass.ExperimentalMethod2();

		//ClassWithExperimentalCode.NonExperimentalMethod();
		//ClassWithExperimentalCode.ExperimentalMethod();

	}

}