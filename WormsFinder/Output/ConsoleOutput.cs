namespace WormsFinder.Output;

public class ConsoleOutput : IOutputHandler
{
	public void WriteOutput(string output)
	{
		Console.WriteLine(output);
	}
}