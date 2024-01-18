namespace d02_ex00.Models;

public readonly struct ExchangeRate
{
	public ExchangeRate(string currency, double rate)
	{
		Currency = currency;
		Rate = rate;
	}

	public string Currency { get; }
	public double Rate { get; }

	public override string ToString()
	{
		return $"{Currency} {Rate}";
	}
}