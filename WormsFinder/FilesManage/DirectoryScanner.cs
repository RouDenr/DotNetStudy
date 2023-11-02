namespace WormsFinder.FilesManage;

public class DirectoryScanner
{
	public List<FileStream> ScanDirectory(string directoryPath)
	{
		var files = Directory.GetFiles(directoryPath);
		var fileStreams = new List<FileStream>();
		if (fileStreams == null) throw new ArgumentNullException(nameof(fileStreams));

		foreach (var filename in files)
		{
			try
			{
				fileStreams.Add(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
		
		return fileStreams;
	}
}