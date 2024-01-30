// Entity Framework

using NLog;
using RegisterApp.Model;

namespace RegisterApp.Model
{

    public static class Registration
	{

		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		
		public static void Register(string login, string password)
		{
			Logger.Info($"Registering user {login}");
			
			
			using var db = new UserDbContext();
			db.Database.EnsureCreated();
			
			bool isUserExists = db.Users.Any(user => user.Login == login);
			if (isUserExists)
			{
				Logger.Info($"User {login} already exists");
				throw new UserAlreadyExistsException();
			}
			
			byte[] salt = UserDbContext.GenerateSalt();
			var passwordHash = UserDbContext.GeneratePasswordHash(password, salt);

			var user = new User { Login = login, Password = passwordHash, Salt = salt };

			db.Users.Add(user);
			db.SaveChanges();
			
			Logger.Info($"User {login} registered");
		}

	}
}