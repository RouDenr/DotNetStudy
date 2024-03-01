using d02_ex00;
using d02_ex00.Models;

try 
{
	GetValue(out string inputSum, out string ratesDirectory);
	
	Console.WriteLine($"Amount in the original currency: {inputSum}");
	
	var exchanger = new Exchanger();
	exchanger.LoadRates(ratesDirectory);
	var sum = ExchangeSum.Parse(inputSum);
	var convertedSums = exchanger.Convert(sum);
	foreach (var convertedSum in convertedSums)
	{
		// Amount in RUB: 8,990.38 RUB
		Console.WriteLine(convertedSum);
	}
}
catch (Exception e)
{
	Console.WriteLine(e.Message);
}


void GetValue(out string s, out string ratesDirectory1)
{
	if (args.Length != 2)
	{
		s = "100 RUB";
		if (Directory.Exists("ratesTest"))
		{
			ratesDirectory1 = "ratesTest";
		}
		else
		{
			ShowAllFilesInCurrentDirectory();
			throw new ArgumentException("Input error. Check the input data and repeat the request.");
		}
	}
	else
	{
		s = args[0];
		ratesDirectory1 = args[1];
		
		if (!Directory.Exists(ratesDirectory1))
		{
			throw new ArgumentException("Input error. Check the input data and repeat the request.");
		}
	}
}

void ShowAllFilesInCurrentDirectory()
{
	// show all files in the current directory
	DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
	FileInfo[] files = directory.GetFiles();
	DirectoryInfo[] directories = directory.GetDirectories();
	Console.WriteLine($"Files in the current directory { directory.FullName } :");
	foreach (FileInfo file in files)
	{
		Console.WriteLine(file.Name);
	}
	Console.WriteLine($"Directories in the current directory { directory.FullName } :");
	foreach (DirectoryInfo dir in directories)
	{
		Console.WriteLine(dir.Name);
	}
}