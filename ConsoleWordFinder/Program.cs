using System;
using DomainWordFinder;

public class Program
{
	public static void Main(string[] args)
	{
		var matrix = new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
		
		var wordstream = new string[] { "chill", "cold", "wind", "cloud" };

		if (args.Length > 0)
			wordstream = args;

		string search = string.Empty;
		Console.WriteLine("Matrix:");
		Console.WriteLine();
		foreach (var item in matrix)
        	{
			Console.WriteLine(item);
		}		

		Console.WriteLine();
		Console.Write("Search terms separated by comma: " + string.Join(",", wordstream));
		Console.WriteLine();

		try
		{
			IWordFinderService wordFinderService = new WordFinderService(matrix);
			var result = wordFinderService.Find(wordstream);
			Console.WriteLine();
			Console.Write("Search result: ");
			Console.Write(string.Join(",", result));
		}
		catch (Exception ex){
			Console.WriteLine();
			Console.Write("Error: " + ex.Message);
		}
				
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("Press any key to close");
		Console.ReadKey();
	}
}
