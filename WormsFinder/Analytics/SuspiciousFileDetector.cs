using System.Text;

namespace WormsFinder.Analytics;

public class SuspiciousFileDetector : IFileDetector
{
	public struct Result
	{
		public SuspiciousCase SuspiciousCase;
		public FileInfo FileInfo;

		public override string ToString()
		{
			return $"Suspicious case: {SuspiciousCase}, file name: {FileInfo.Name}";
		}
	}

	public enum SuspiciousCase
	{
		JsEvilScript,
		Rmfr,
		Rundll32,
		Error,
		Ok
	}

	private static readonly Dictionary<SuspiciousCase, string> SuspiciousCases = new()
	{
		{SuspiciousCase.JsEvilScript, "<script>evil_script()</script>"},
		{SuspiciousCase.Rmfr, "rm -rf %userprofile%\\Documents"},
		{SuspiciousCase.Rundll32, "Rundll32 sys.dll SysEntry"}
	};

	private const int BufferSize = 1024;


	public Result SelectFile(FileStream file)
	{
		Result result = new();
		result.FileInfo = new FileInfo(file.Name);
		byte[] buffer = new byte[BufferSize];
		int read = 0;
		while ((read = file.Read(buffer, 0, BufferSize)) > 0)
		{
			if (IsSuspiciousFile(buffer) == SuspiciousCase.Ok) continue;
			
			result.SuspiciousCase = SuspiciousCase.JsEvilScript;
			return result;
		}

		return result;
	}
	
	public T SelectFile<T>(FileStream file)
	{
		return (T) (object) SelectFile(file);
	}

	private SuspiciousCase IsSuspiciousFile(byte[] fileContent)
	{
		SuspiciousCase suspiciousCase = SuspiciousCase.Ok;

		foreach (var suspiciousCaseKey in SuspiciousCases.Keys)
		{
			if (!Encoding.UTF8.GetString(fileContent).Contains(SuspiciousCases[suspiciousCaseKey])) continue;
			
			suspiciousCase = suspiciousCaseKey;
			break;
		}
		
		return suspiciousCase;
	}
}