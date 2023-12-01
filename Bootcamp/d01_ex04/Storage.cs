namespace d01_ex04;

public class Storage
{
	private int Goods { get; set; }
	private int Capacity { get; set; }
	
	public Storage(int capacity)
	{
		if (capacity <= 0)
		{
			throw new ArgumentException("Capacity must be greater than 0");
		}
		
		Capacity = capacity;
		Goods = 0;
	}
	
	public bool IsEmpty => Goods == 0;
}