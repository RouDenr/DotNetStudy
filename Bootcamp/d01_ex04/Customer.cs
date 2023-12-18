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
	
	public void FillCart(int maxGoodsCount)
	{
		// random number from 1 to maxGoodsCount
		GoodsCount = new Random().Next(maxGoodsCount) + 1;
		
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
