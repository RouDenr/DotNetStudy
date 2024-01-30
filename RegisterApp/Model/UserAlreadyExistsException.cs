namespace RegisterApp.Model;

public class UserAlreadyExistsException : Exception
{
	public override string Message { get; } = "User already exists";
}