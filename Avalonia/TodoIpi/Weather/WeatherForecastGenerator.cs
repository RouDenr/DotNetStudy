namespace TodoIpi.Weather;

public class WeatherForecastGenerator : IWeatherForecastGenerator
{
	private readonly string[] _summaries =
	{
		"Заморозки",
		"Освежающий",
		"Холодно",
		"Прохладно",
		"Тепло",
		"Жарко",
		"Лето",
		"Жара", "Жара",
		"Адская жара"
	};

	public WeatherForecast[] Generate()
	{
		return Enumerable.Range(1, 5).Select(CreateForecast).ToArray();
	}

	private WeatherForecast CreateForecast(int index)
	{
		return new WeatherForecast(
			DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			Random.Shared.Next(-20, 55),
			_summaries[Random.Shared.Next(_summaries.Length)]
			);
	}
}