namespace RegisterApp.Model;

public class UserNotExistsException : Exception
{
	public override string Message { get; } = "User already exists";
}