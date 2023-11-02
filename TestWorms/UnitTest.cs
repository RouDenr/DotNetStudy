using Moq;
using WormsFinder;
using WormsFinder.Analytics;
using WormsFinder.FilesManage;
using WormsFinder.Input;
using WormsFinder.Output;

namespace TestWorms;

public class UnitTest
{

	[Fact]
	public void DirectoryPathIsIncorrect()
	{
		var inputHandleMock = new Mock<IInputHandler>();
		var directoryScannerMock = new Mock<DirectoryScanner>();
		var fileDetectorMock = new Mock<IFileDetector>();
		var outputHandlerMock = new Mock<IOutputHandler>();

		inputHandleMock.Setup(i => i.GetInput()).Returns("incorrect_path");
		
		Manager manager = new Manager(inputHandleMock.Object, directoryScannerMock.Object,
			fileDetectorMock.Object, outputHandlerMock.Object);
		
		manager.Run();
		
		outputHandlerMock.Verify(o => o.WriteOutput(It.IsAny<string>()), Times.AtLeastOnce);
	}
	[Fact]
	public void NotSuspiciousFiles()
	{
		var inputHandleMock = new Mock<IInputHandler>();
		var directoryScannerMock = new Mock<DirectoryScanner>();
		var fileDetectorMock = new Mock<IFileDetector>();
		var outputHandlerMock = new Mock<IOutputHandler>();

		inputHandleMock.Setup(i => i.GetInput()).Returns(@"D:\project\safeBoard\SafeBoard\TestWorms\case00");
		
		Manager manager = new Manager(inputHandleMock.Object, directoryScannerMock.Object,
			fileDetectorMock.Object, outputHandlerMock.Object);
		
		manager.Run();
		
		outputHandlerMock.Verify(o => o.WriteOutput(It.IsAny<string>()), Times.AtLeastOnce);
	}
	[Fact]
	public void SuspiciousFiles()
	{
		var inputHandleMock = new Mock<IInputHandler>();
		var directoryScannerMock = new Mock<DirectoryScanner>();
		var fileDetectorMock = new Mock<IFileDetector>();
		var outputHandlerMock = new Mock<IOutputHandler>();

		inputHandleMock.Setup(i => i.GetInput()).Returns(@"D:\project\safeBoard\SafeBoard\TestWorms\case01");
		
		Manager manager = new Manager(inputHandleMock.Object, directoryScannerMock.Object,
			fileDetectorMock.Object, outputHandlerMock.Object);
		
		manager.Run();
		
		outputHandlerMock.Verify(o => o.WriteOutput(It.IsAny<string>()), Times.AtLeastOnce);
	}

	[Fact]
	public void SelectFile_JsCaseOnlyForJsFiles_Test()
	{
		// Arrange
		var jsContent = "<script>evil_script()</script>";
		var nonJsContent = "<script>evil_script()</script>";

		var jsTempPath = Path.GetTempFileName() + ".js";
		var txtTempPath = Path.GetTempFileName() + ".txt";

		File.WriteAllText(jsTempPath, jsContent);
		File.WriteAllText(txtTempPath, nonJsContent);


		var fileDetector = new SuspiciousFileDetector();

		// Act

		SuspiciousFileDetector.Result jsResult;
		SuspiciousFileDetector.Result nonJsResult;

		using (var jsFileStream = new FileStream(jsTempPath, FileMode.Open, FileAccess.ReadWrite))
		{
			jsResult = fileDetector.SelectFile(jsFileStream);
		}

		using (var nonJsFileStream = new FileStream(txtTempPath, FileMode.Open, FileAccess.ReadWrite))
		{
			nonJsResult = fileDetector.SelectFile(nonJsFileStream);
		}
		

		// Assert
		Assert.Equal(SuspiciousCase.JsEvilScript, jsResult.SuspiciousCase);
		Assert.Equal(SuspiciousCase.Ok, nonJsResult.SuspiciousCase);

		File.Delete(jsTempPath);
		File.Delete(txtTempPath);
	}

	[Fact]
	public void SelectFile_SuspicionCaseRMRF_Test()
	{
		// Arrange
		var suspiciousContent = "Hi!\n" +
		                        "rm -rf %userprofile%\\Documents\n" +
		                        "My name is Alex\n";
		var tempPath = Path.GetTempFileName();
		File.WriteAllText(tempPath, suspiciousContent);
		var fileDetector = new SuspiciousFileDetector();
		SuspiciousFileDetector.Result result;

		// Act
		using (var fileStream = new FileStream(tempPath, FileMode.Open, FileAccess.ReadWrite))
		{
			result = fileDetector.SelectFile(fileStream);
		}

		// Assert
		Assert.Equal(SuspiciousCase.Rmfr, result.SuspiciousCase);

		// Clean up
		File.Delete(tempPath);
	}

	[Fact]
	public void FileWithNotAccess()
	{
		
	}
}