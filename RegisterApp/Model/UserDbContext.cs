using RegisterApp.Model;
using Microsoft.EntityFrameworkCore;

namespace RegisterApp.Model
{
	public class UserDbContext : DbContext
	{
        private const string DbNAme = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234";
		public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DbNAme);
       
            // check connection
   //          try
			// {
			// 	Database.OpenConnection();
			// 	Database.CloseConnection();
			// }
			// catch
			// {
			// 	Database.EnsureCreated();
			// }
        }
    }
} 