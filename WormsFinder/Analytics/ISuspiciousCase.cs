namespace WormsFinder.Analytics;

public enum SuspiciousCase
{
	JsEvilScript,
	Rmfr,
	Rundll32,
	Error,
	Ok
}

public interface ISuspiciousCase
{
	SuspiciousCase Case { get; }
	string Name { get; }
	string SuspiciousCaseString { get; }
	bool IsSuspiciousFile(byte[] content, string fileName);
}