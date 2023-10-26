namespace WormsFinder.Analytics;

public interface IFileDetector
{
	public T SelectFile<T>(FileStream file);
}