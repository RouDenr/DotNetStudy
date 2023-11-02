namespace WormsFinder.Input;

public class ConsoleInput : IInputHandler
{
	public string GetInput()
	{
		return Console.ReadLine() ?? string.Empty;
	}
}