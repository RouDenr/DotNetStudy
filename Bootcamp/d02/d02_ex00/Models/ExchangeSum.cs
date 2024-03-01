using System.Globalization;

namespace d02_ex00.Models
{
    public readonly struct ExchangeSum
    {
        public ExchangeSum(string currency, double amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public string Currency { get; }
        public double Amount { get; }

        public static ExchangeSum Parse(string sum)
        {
            var parts = sum.Split(' ');
            return new ExchangeSum(parts[1], double.Parse(parts[0]));
        }

        public override string ToString()
        {
            // Amount in RUB: 8,990.38 RUB
            return $"Amount in {Currency}: " +
                   $"{Amount.ToString("C", CultureInfo.CreateSpecificCulture("ru-RU"))}" +
                   $"{Currency}";
        }
        
    }
}