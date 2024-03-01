namespace d02_ex00.Models
{
    public readonly struct ExchangeRate
    {
        public ExchangeRate(string fromCurrency, string toCurrency, double rate)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Rate = rate;
        }

        public string FromCurrency { get; }
        public string ToCurrency { get; }
        public double Rate { get; }

        public static ExchangeRate Parse(string from, string line)
        {
            var parts = line.Split(':');
            if (parts.Length != 2)
            {
                throw new Exception("Invalid rate format");
            }
            
            return new ExchangeRate(from, parts[0], double.Parse(parts[1]));
        }

        public override string ToString()
        {
            return $"{FromCurrency} to {ToCurrency}: {Rate}";
        }
    }
}