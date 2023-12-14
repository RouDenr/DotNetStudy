using System.Reflection;
using TodoIpi.ConfigureServices.Api;
using TodoIpi.Weather;

namespace TodoIpi.ConfigureServices;

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
		services.AddSingleton<IWeatherForecastGenerator, WeatherForecastGenerator>();
	}
	
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			// Используем Swagger для автогенерации документации API
			app.UseSwagger();
			// И специальный UI для просмотра этой документации
			app.UseSwaggerUI();
		}
		
		app.UseHttpsRedirection();
		
		if (app is not WebApplication webApplication) return;
		var apiCommands = typeof(RouteHandlers).GetMethods();

		foreach (var command in apiCommands)
		{
			var endpoint = command.GetCustomAttributes<ApiCommandAttribute>();

			foreach (var endpointAttribute in endpoint)
			{
				Delegate handler = Delegate.CreateDelegate(
					typeof(Func<HttpContext, IWeatherForecastGenerator,Task>),
					command
					);
				webApplication.MapMethods(endpointAttribute.Route, new[] { endpointAttribute.HttpMethod }, handler)
					.WithName(endpointAttribute.Name);
			}
		}


	}
}