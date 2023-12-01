namespace d01_ex03;

public class Customer(string name, int id)
{
	private int Id { get; } = id;
	private string Name { get; } = name;
	public int GoodsCount { get; private set; } = 0;
	
	
	public void FillCart(int maxGoodsCount)
	{
		GoodsCount = new Random().Next(maxGoodsCount);
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
