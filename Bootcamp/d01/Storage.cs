namespace d01_ex04;

public class Storage
{
	public int Goods { get; private set; }
	private int Capacity { get;  set; }
	
	public Storage(int capacity)
	{
		if (capacity <= 0)
		{
			throw new ArgumentException("Capacity must be greater than 0");
		}
		
		Capacity = capacity;
		Goods = 0;
	}
	
	public Storage(int capacity, int goods)
	{
		if (capacity <= 0)
		{
			throw new ArgumentException("Capacity must be greater than 0");
		}
		
		if (goods < 0)
		{
			throw new ArgumentException("Goods must be greater than or equal to 0");
		}
		
		Capacity = capacity;
		Goods = Math.Min(goods, capacity);
	}
	
	public void AddGoods(int goodsCount)
	{
		if (goodsCount <= 0)
		{
			throw new ArgumentException("Goods count must be greater than 0");
		}
		
		Goods = Math.Min(goodsCount + Goods, Capacity);
	}
	
	public int TakeGoods(int goodsCount)
	{
		if (goodsCount <= 0)
		{
			throw new ArgumentException("Goods count must be greater than 0");
		}
		
		if (Goods == 0)
		{
			return 0;
		}
		
		int takenGoods = Math.Min(goodsCount, Goods);
		Goods -= takenGoods;
		return takenGoods;
	}
	
	public bool IsEmpty => Goods == 0;
}