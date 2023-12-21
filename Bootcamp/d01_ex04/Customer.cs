namespace d01_ex04;

public class Customer
{
	private int Id { get; }
	private string Name { get; }
	public int GoodsCount { get; private set; } = 0;
	
	
	public Customer(string name, int id)
	{
		Id = id;
		Name = name;
	}
	
	public void FillCart(int maxGoodsCount, Storage storage)
	{
		if (GoodsCount >= maxGoodsCount || storage.IsEmpty)
		{
			return;
		}
		
		int goodsCount = new Random().Next(1, maxGoodsCount - GoodsCount + 1);
		GoodsCount = storage.TakeGoods(goodsCount);
	}
	

	#region standard methods
	public override string ToString()
	{
		return new string($"{Name}, customer #{Id} ({GoodsCount} items in cart)");
	}

	public override bool Equals(object? obj)
	{
		return obj is Customer customer && Equals(customer);
	}

	private bool Equals(Customer other)
	{
		return Id == other.Id && Name == other.Name;
	}
	
	public static bool operator ==(Customer? left, Customer? right)
	{
		return Equals(left, right);
	}
	public static bool operator !=(Customer? left, Customer? right)
	{
		return !Equals(left, right);
	}
	
	public override int GetHashCode()
	{
		return HashCode.Combine(Id, Name);
	}
	#endregion
}
