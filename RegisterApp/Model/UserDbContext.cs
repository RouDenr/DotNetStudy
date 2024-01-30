using RegisterApp.Model;
using Microsoft.EntityFrameworkCore;

namespace RegisterApp.Model
{
	public class UserDbContext : DbContext
	{
		
        private const string DbNAme = "Host=localhost;Port=5433;Database=users;Username=postgres;Password=4321";
		public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DbNAme);
        }
        
        
		
        public static byte[] GeneratePasswordHash(string password, byte[] salt)
        {
	        // Hash the password and encode the parameters.
	        return new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);
        }
        
        public static byte[] GenerateSalt()
        {
	        var buff = new byte[32];
			
	        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
	        rng.GetBytes(buff);
			
	        return buff;
        }
    }
} 