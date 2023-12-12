
using TodoIpi.Weather;

// Создаём новый экземпляр билдера приложения с передачей аргументов командной строки
var builder = WebApplication.CreateBuilder(args);

// Добавляем в контейнер сервисы для работы с API
builder.Services.AddEndpointsApiExplorer();

// Добавляем в контейнер сервисы для работы со Swagger для описания и документирования API
// Дополнительную информацию о настройке Swagger/OpenAPI можно найти тут: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

// Строим приложение из билдера
builder.Services.AddSingleton<IWeatherForecastGenerator, WeatherForecastGenerator>();
WebApplication app = builder.Build();

// Добавляем конфигурацию промежуточного программного обеспечения (middleware)
if (app.Environment.IsDevelopment())
{
    // Если приложение в режиме разработки, то используем Swagger для автогенерации документации API
    app.UseSwagger();
    // И специальный UI для просмотра этой документации
    app.UseSwaggerUI();
}

// Все HTTP запросы будут автоматически переадресовываться на HTTPS
app.UseHttpsRedirection();


// Определяем HTTP GET запрос по пути "/weatherforecast" 
app.MapGet("/weatherforecast", (IWeatherForecastGenerator forecastGenerator) => forecastGenerator.Generate())
.WithName("GetWeatherForecast") // Даем имя этому маршруту
.WithOpenApi(); // И открываем его в OpenAPI 

// Запуск приложения
app.Run();