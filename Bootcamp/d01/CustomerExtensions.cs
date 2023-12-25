namespace d01_ex04;

public static class CustomerExtensions
{
	public static CashRegister CashRegisterWithMinCustomers(CashRegister[] cashRegisters)
	{
		CashRegister minQueue = cashRegisters[0];
		foreach (var cashRegister in cashRegisters)
		{
			if (cashRegister.CustomerCount < minQueue.CustomerCount)
			{
				minQueue = cashRegister;
			}
		}

		return minQueue;
	}
	public static CashRegister CashRegisterWithMinGoods(CashRegister[] cashRegisters)
	{
		CashRegister minGoods = cashRegisters[0];
		foreach (var cashRegister in cashRegisters)
		{
			if (cashRegister.GoodsCount < minGoods.GoodsCount)
			{
				minGoods = cashRegister;
			}
		}

		return minGoods;
	}
}