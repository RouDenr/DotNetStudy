
using TodoIpi.ConfigureServices;

// Создаём новый экземпляр билдера приложения с передачей аргументов командной строки
var builder = WebApplication.CreateBuilder(args);
Startup startup = new();
startup.ConfigureServices(builder.Services);

WebApplication app = builder.Build();
startup.Configure(app, builder.Environment);

// Запуск приложения
app.Run();