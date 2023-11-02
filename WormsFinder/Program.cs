using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WormsFinder.Analytics;
using WormsFinder.FilesManage;
using WormsFinder.Input;
using WormsFinder.Output;

namespace WormsFinder;

public class Program
{
	public static void Main(string[] args)
	{
		var host = CreateHostBuilder(args).Build();
		var serviceScope = host.Services.CreateScope();
		var services = serviceScope.ServiceProvider;

		try
		{
			var manager = services.GetRequiredService<Manager>();
			manager.Run();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
		finally
		{
			serviceScope.Dispose();
		}
	}

	private static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureServices((_, services) =>
			{
				services.AddTransient<IInputHandler, ConsoleInput>();
				services.AddTransient<DirectoryScanner>();
				services.AddTransient<IFileDetector, SuspiciousFileDetector>();
				services.AddTransient<IOutputHandler, ConsoleOutput>();
				services.AddTransient<Manager>();
			});
}