using System.Configuration;
using System.Data;
using System.Windows;
using NLog;

namespace RegisterApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public App()
	{
		var logConfig = new NLog.Config.LoggingConfiguration();
		
		var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
		var logConsole = new NLog.Targets.ConsoleTarget("logconsole");
		
		logConfig.AddRule(LogLevel.Info, LogLevel.Fatal, logConsole);
		logConfig.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
		
		LogManager.Configuration = logConfig;
		
		Logger.Info("Program started");
	}
	
}