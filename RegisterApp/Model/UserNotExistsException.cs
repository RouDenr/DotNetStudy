namespace RegisterApp.Model;

public class UserNotExistsException : Exception
{
	public override string Message { get; } = "User not exists";
}