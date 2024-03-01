using d02_ex00.Models;

namespace d02_ex00
{
    public class Exchanger
    {
        private readonly List<ExchangeRate> _rates = new();

        public void LoadRates(string ratesDirectory)
        {
            foreach (var file in Directory.GetFiles(ratesDirectory))
            {
                var lines = File.ReadLines(file);
                _rates.AddRange(lines.Select(l 
                    => ExchangeRate.Parse(Path.GetFileNameWithoutExtension(file), l)));
            }
        }
        
        public IEnumerable<ExchangeSum> Convert(ExchangeSum sum)
        {
            foreach (var rate in _rates.Where(r => r.FromCurrency == sum.Currency))
            {
                yield return new ExchangeSum(rate.ToCurrency, sum.Amount * rate.Rate);
            }
        }
    }
}