namespace d02_ex00.Models;

public readonly struct ExchangeSum
{
	public ExchangeSum(string currency, double amount)
	{
		Currency = currency;
		Amount = amount;
	}

	public string Currency { get; }
	public double Amount { get; }

	public override string ToString()
	{
		return $"{Amount} {Currency}";
	}
}