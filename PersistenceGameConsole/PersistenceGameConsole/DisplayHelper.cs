using System;
namespace PersistenceGameConsole
{
	static class DisplayHelper
	{
		public static void WriteLine(string message)
		{
			var originalColor = Console.ForegroundColor;

			Console.ForegroundColor = ConsoleColor.Green;

			Console.WriteLine(message);

			Console.ForegroundColor = originalColor;
		}
	}
}

