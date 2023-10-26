namespace WormsFinder.FilesManage;

public class DirectoryScanner
{
	public List<FileStream> ScanDirectory(string directoryPath)
	{
		var files = Directory.GetFiles(directoryPath);

		return files.Select(file => new FileStream(file, FileMode.Open)).ToList();
	}
}