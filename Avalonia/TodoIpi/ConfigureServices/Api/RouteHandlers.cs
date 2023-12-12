using TodoIpi.Weather;

namespace TodoIpi.ConfigureServices.Api;

public static class RouteHandlers
{
	[ApiCommand("/weatherforecast", "GetWeatherForecast", "GET")]
	public static async Task GetWeatherForecast(HttpContext context, 
		IWeatherForecastGenerator forecastGenerator)
	{
		var forecasts = forecastGenerator.Generate();
		await context.Response.WriteAsJsonAsync(forecasts);
	}
}