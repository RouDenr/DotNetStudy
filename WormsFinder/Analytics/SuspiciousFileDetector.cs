using WormsFinder.Utils;

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

	private static readonly List<ISuspiciousCase> SuspiciousCases = new()
	{
		new ExtensionSuspiciousCase(SuspiciousCase.JsEvilScript,
			"<script>evil_script()</script>", "JS", ".js"),
		new BaseSuspiciousCase(SuspiciousCase.Rmfr, "rm -rf %userprofile%\\Documents", "rm -rf"),
		new BaseSuspiciousCase(SuspiciousCase.Rundll32, "Rundll32 sys.dll SysEntry", "Rundll32"),
	};

	private const int BufferSize = 1024;


	public Result SelectFile(FileStream file)
	{
		Result result = new()
		{
			FileInfo = new FileInfo(file.Name), 
			SuspiciousCase = SuspiciousCase.Ok
		};

		int maxPhraseLength = SuspiciousCases.Max(s => s.SuspiciousCaseString.Length);
		// RollingBuffer rollingBuffer = new(maxPhaseLenght);
		byte[] buffer = new byte[BufferSize];
		int read;
		
		// Первоначальное чтение файла.
		if((read = file.Read(buffer, 0, BufferSize)) > 0)
		{
			result.SuspiciousCase = IsSuspiciousFile(buffer.Take(read).ToArray(), file.Name);
		}

		while (file.Position < file.Length && result.SuspiciousCase == SuspiciousCase.Ok)
		{
			// Сохраняем последние 'maxPhraseLength' байт.
			Array.Copy(buffer, BufferSize - maxPhraseLength, buffer, 0, maxPhraseLength);

			// Считываем следующие 'BufferSize - maxPhraseLength' байт.
			if((read = file.Read(buffer, maxPhraseLength, BufferSize - maxPhraseLength)) > 0)
			{
				result.SuspiciousCase = IsSuspiciousFile(buffer.Take(maxPhraseLength + read).ToArray(), file.Name);
			}
		}

		return result;
	}
	
	public T SelectFile<T>(FileStream file)
	{
		return (T) (object) SelectFile(file);
	}

	private SuspiciousCase IsSuspiciousFile(byte[] fileContent, string fileName)
	{
		SuspiciousCase suspiciousCase = SuspiciousCase.Ok;

		foreach (var suspiciousCaseKey in SuspiciousCases)
		{
			if (!suspiciousCaseKey.IsSuspiciousFile(fileContent, fileName)) continue;
			
			suspiciousCase = suspiciousCaseKey.Case;
			break;
		}
		
		return suspiciousCase;
	}
}