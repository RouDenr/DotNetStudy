using System.ComponentModel;

namespace d01_ex04;

public class Store
{
	private Storage Storage { get; }
	public CashRegister[] CashRegisters { get; }
	
	public Store(int capacity, int cashRegistersCount)
	{
		Storage = new Storage(capacity);
		CashRegisters = new CashRegister[cashRegistersCount];

		for (int i = 0; i < cashRegistersCount; i++)
		{
			CashRegisters[i] = new CashRegister($"Register #{i + 1}");
		}
	}
	
	public bool IsOpen => !Storage.IsEmpty;
}