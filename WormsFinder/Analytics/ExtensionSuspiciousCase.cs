namespace WormsFinder.Analytics;

public class ExtensionSuspiciousCase : BaseSuspiciousCase
{
	private readonly string _extension;

	public ExtensionSuspiciousCase(SuspiciousCase suspiciousCase,
		string suspiciousCaseString, string name, string extension) : base(suspiciousCase, suspiciousCaseString, name)
	{
		_extension = extension;
	}

	public override bool IsSuspiciousFile(byte[] content, string fileName)
	{
		return fileName.EndsWith(_extension) && base.IsSuspiciousFile(content, fileName);
	}
}