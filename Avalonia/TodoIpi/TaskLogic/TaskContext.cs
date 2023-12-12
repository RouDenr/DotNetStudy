using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace TodoIpi.TaskLogic;

public class TaskContext : DbContext
{
	public DbSet<TaskItem> Tasks { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connect = optionsBuilder.UseSqlite("Data Source=tasks.db");
		
		if (Debugger.IsAttached)
		{
			connect.EnableSensitiveDataLogging();
			if (connect.IsConfigured)
			{
				var context = new TaskContext();
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
			}
			else
			{
				throw new InvalidOperationException("Context is not configured");
			}
		}
	}
}