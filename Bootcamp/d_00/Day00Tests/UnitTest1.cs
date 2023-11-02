using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Day00Tests;

public class UnitTest1
{
	[Fact]
	public void Test_00()
	{
		using var fakeOut = new StringWriter();
		Console.SetOut(fakeOut);
		string[] argv = "1000000 12 10".Split();
		
		Program.Main(argv);
		
		var expected = "1200000";
		Assert.Equal(expected, fakeOut.ToString().Trim());
	}
}