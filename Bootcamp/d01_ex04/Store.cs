using System.ComponentModel;

namespace d01_ex04;

public class Store
{
	private CashRegister[] CashRegisters { get; }
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
		
		customer.FillCart(MaxGoodsCount, Storage);
		cashRegister.AddCustomer(customer);
	}
	
	public bool IsOpen => !Storage.IsEmpty || Customers.Count > 0;
}