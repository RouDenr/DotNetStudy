using Microsoft.Extensions.DependencyInjection;
using WormsFinder.Analytics;
using WormsFinder.FilesManage;
using WormsFinder.Input;
using WormsFinder.Output;

namespace WormsFinder;

public class Manager
{
	private readonly IInputHandler _inputHandler;
	private readonly DirectoryScanner _directoryScanner;
	private readonly IFileDetector _suspiciousFileDetector;
	private readonly IOutputHandler _outputHandler;

	public Manager(IInputHandler inputHandler, DirectoryScanner directoryScanner,
		IFileDetector fileDetector, IOutputHandler outputHandler)
	{
		_inputHandler = inputHandler;
		_directoryScanner = directoryScanner;
		_suspiciousFileDetector = fileDetector;
		_outputHandler = outputHandler;
	}
	public void Run()
	{
		_outputHandler.WriteOutput("Enter the path to the directory:");
		var path = _inputHandler.GetInput();
		var files = _directoryScanner.ScanDirectory(path);
		List<SuspiciousFileDetector.Result> suspiciousFiles = files.Select(file =>
			_suspiciousFileDetector.SelectFile<SuspiciousFileDetector.Result>(file)).ToList();
		
		_outputHandler.WriteOutput("Suspicious files:");
		foreach (SuspiciousFileDetector.Result suspiciousFile in suspiciousFiles)
		{
			_outputHandler.WriteOutput(suspiciousFile.ToString());
		}
	}
}