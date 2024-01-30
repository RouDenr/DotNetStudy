namespace RegisterApp.Model;

public class WrongPasswordException : Exception
{
	public override string Message { get; } = "Wrong password";
}