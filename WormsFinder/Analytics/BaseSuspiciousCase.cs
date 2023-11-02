using System.Text;

namespace WormsFinder.Analytics;

public class BaseSuspiciousCase : ISuspiciousCase
{
	public SuspiciousCase Case { get; }
	public string Name { get; }
	public  string SuspiciousCaseString { get; }

	public BaseSuspiciousCase(SuspiciousCase suspiciousCase,
		string suspiciousCaseString, string name)
	{
		Case = suspiciousCase;
		SuspiciousCaseString = suspiciousCaseString;
		Name = name;
	}

	public virtual bool IsSuspiciousFile(byte[] content, string fileName)
	{
		return Encoding.UTF8.GetString(content).Contains(SuspiciousCaseString);
	}
}