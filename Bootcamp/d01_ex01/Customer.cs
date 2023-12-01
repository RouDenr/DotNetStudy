namespace d01_ex01;

public class Customer(string name, int id)
{
	private int Id { get; } = id;
	private string Name { get; } = name;

	public override string ToString()
	{
		return new string($"{Name}, customer #{Id}");
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
}