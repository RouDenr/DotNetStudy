using System.ComponentModel;

namespace d01_ex04;

public class Store
{
	public CashRegister[] CashRegisters { get; }
	private List<Customer> Customers { get; }
	private Storage Storage { get; }
	private int MaxGoodsCount { get; }
	
	public Store(int capacity, int cashRegistersCount, int maxGoodsCount = 7)
	{
		if (capacity <= 0)
		{
			throw new ArgumentException("Capacity must be greater than 0");
		}
		if (cashRegistersCount <= 0)
		{
			throw new ArgumentException("Cash registers count must be greater than 0");
		}
		if (maxGoodsCount <= 0)
		{
			throw new ArgumentException("Max goods count must be greater than 0");
		}
		
		Storage = new Storage(capacity);
		CashRegisters = new CashRegister[cashRegistersCount];
		MaxGoodsCount = maxGoodsCount;

		for (int i = 0; i < cashRegistersCount; i++)
		{
			CashRegisters[i] = new CashRegister($"Register #{i + 1}");
		}
		Customers = new List<Customer>();
		Storage.AddGoods(capacity);
		
	}
	
	public Store(int capacity, int cashRegistersCount,int maxGoodsCount, int customersCount) 
		: this(capacity, cashRegistersCount, maxGoodsCount)
	{
		if (customersCount <= 0)
		{
			throw new ArgumentException("Customers count must be greater than 0");
		}
		
		Customers = new List<Customer>(customersCount);
	}
	
	public void Enter(Customer customer, CashRegister cashRegister)
	{
		if (customer is null)
		{
			throw new ArgumentNullException(nameof(customer));
		}
		if (cashRegister is null || !CashRegisters.Contains(cashRegister))
		{
			throw new ArgumentNullException(nameof(cashRegister));
		}
		
		if (customer.GoodsCount > MaxGoodsCount)
		{
			throw new ArgumentException("Goods count is out of range");
		}
		
		if (Storage.IsEmpty)
		{
			return;
		}
		
		customer.FillCart(MaxGoodsCount);
		cashRegister.AddCustomer(customer);
		Customers.Add(customer);
		
		// Andrew, Customer #4 (6 items in cart) - Register #1 (4 people with 20 items behind)
		Console.WriteLine($"{customer.Name}, Customer #{customer.Id} ({customer.GoodsCount} items in cart)" +
		                  $" - {cashRegister} ({cashRegister.CustomerCount} people with {cashRegister.GoodsCount} items behind)");
	}
	
	public void Next()
	{
		if (Customers.Count == 0)
		{
			return;
		}

		foreach (var register in CashRegisters)
		{
			var customer = register.GetCustomer();
			
			if (customer is null)
			{
				continue;
			}
			customer.Pay(Storage.TakeGoods(customer.GoodsCount));
			
			if (customer.GoodsCount > 0)
			{
				// Andrew, Customer #4 (2 items left in cart)
				Console.WriteLine($"{customer.Name} Customer #{customer.Id}," +
				                  $" ({customer.GoodsCount} items left in cart)");
			}
			Customers.Remove(customer);
		}
	}

	public bool IsOpen => Customers.Count > 0 || (!Storage.IsEmpty && Customers.Count > 0);

	#region	standard methods

	public override string ToString()
	{
		return $"Store with {CashRegisters.Length} cash registers, {Customers.Count} customers and {Storage.Goods} goods in storage";
	}

	#endregion
}