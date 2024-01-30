// Entity Framework

using RegisterApp.Model;

namespace RegisterApp.Model
{

    public class Registration
	{
		// DB connection
		public Registration()
		{
            // DB connection
            
            
        }

		public void Register(string login, string password)
		{
			using var db = new UserDbContext();
			
			byte[] salt = GenerateSalt();
			var passwordHash = GeneratePasswordHash(password, salt);

			var user = new User { Login = login, Password = passwordHash, Salt = salt };

			db.Users.Add(user);
			db.SaveChanges();
		}

		private static byte[] GenerateSalt()
		{
			var buff = new byte[32];
			
			using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
			rng.GetBytes(buff);
			
			return buff;
		}
		
		private static byte[] GeneratePasswordHash(string password, byte[] salt)
		{
			// Hash the password and encode the parameters.
			return new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);
		}
	}
}