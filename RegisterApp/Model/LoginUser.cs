using NLog;

namespace RegisterApp.Model;

public static class LoginUser
{
	private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
	
	public static User? Login(string login, string password)
	{
		Logger.Info($"Login user {login}");

		using var db = new UserDbContext();
		db.Database.EnsureCreated();
		
		User? user = db.Users.FirstOrDefault(u => u.Login == login);
		if (user == null)
		{
			Logger.Info($"User {login} not exists");
			throw new UserNotExistsException();
		}
		CheckPassword(user, password, db);

		return user;
	}

	private static void CheckPassword(User user, string password, UserDbContext db)
	{
		byte[] salt = user.Salt;
		byte[] passwordHash = UserDbContext.GeneratePasswordHash(password, salt);
		bool isPasswordCorrect = passwordHash.SequenceEqual(user.Password);
		if (isPasswordCorrect) return;
		
		Logger.Info("Wrong password");
		throw new WrongPasswordException();
	}
}