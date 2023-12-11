namespace d01_ex03;

public class CashRegister
{
	private string Header { get; }
	private Queue<Customer> Customers { get; } = new();

	public CashRegister(string header)
	{
		Header = header;
	}
	
	public void AddCustomer(Customer customer)
	{
		Customers.Enqueue(customer);
	}
	
	public Customer? GetCustomer()
	{
		return Customers.TryDequeue(out var customer) ? customer : null;
	}
	
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