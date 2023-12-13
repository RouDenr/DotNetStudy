namespace d01_ex04;

public class CashRegister(string header)
{
	private string Header { get; } = header;
	private Queue<Customer> Customers { get; } = new();

	public void AddCustomer(Customer customer)
	{
		Customers.Enqueue(customer);
	}
	
	public Customer? GetCustomer()
	{
		return Customers.TryDequeue(out var customer) ? customer : null;
	}
	public int CustomerCount => Customers.Count;
	public int GoodsCount => Customers.Sum(customer => customer.GoodsCount);
	
	#region	standard methods

	public override string ToString()
	{
		return Header;
	}

	public override bool Equals(object? obj)
	{
		return obj is CashRegister register && Equals(register);
	}

	private bool Equals(CashRegister other)
	{
		return Header == other.Header;
	}

	public static bool operator ==(CashRegister? left, CashRegister? right)
	{
		return Equals(left, right);
	}
	public static bool operator !=(CashRegister? left, CashRegister? right)
	{
		return !Equals(left, right);
	}
	
	public override int GetHashCode()
	{
		return Header.GetHashCode();
	}

	#endregion
	
}