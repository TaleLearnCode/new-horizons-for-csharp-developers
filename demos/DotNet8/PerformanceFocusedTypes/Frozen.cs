using System.Collections.Frozen;

namespace TaleLearnCode.NewHorizons.DotNet8.PerformanceFocusedTypes;

public class Frozen
{

	private static readonly FrozenDictionary<string, bool> _configurationData
		= LoadConfigurationData().ToFrozenDictionary(); // optimizeForReads: true

	private static Dictionary<string, bool> LoadConfigurationData()
	{
		return new Dictionary<string, bool>()
		{
			{ "EnableLogging", true },
			{ "UseSSL", true },
			{ "AllowGuestAccess", false },
			{ "DebugMode", false },
			{ "EnableNotifications", true },
			{ "CacheEnabled", true },
			{ "AllowFileUpload", true },
			{ "AllowCDN", true },
			{ "RequireTwoFactorAuth", true },
			{ "EnableAutoUpdates", false }
		};
	}

	public static void Demo()
	{

		Console.WriteLine();
		Console.WriteLine("------------------------------------");
		Console.WriteLine("Performance-Focused Types: Frozen Collections");
		Console.WriteLine("------------------------------------");

		List<string> keys = [.. _configurationData.Keys];

		for (int execution = 1; execution <= 10; execution++)
		{
			string key = keys[Random.Shared.Next(0, keys.Count)];
			if (_configurationData.TryGetValue(key, out bool setting) && setting)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"Execution {execution}: {key} is set to {setting}");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Execution {execution}: {key} is set to false");
			}
			Console.ResetColor();
		}

		Console.WriteLine();

	}


}