using TodoIpi.TaskLogic;

// Создаём новый экземпляр билдера приложения с передачей аргументов командной строки
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<TaskContext>();

if (builder.Environment.IsDevelopment())
{
	builder.Services.AddSwaggerGen();
}

WebApplication app = builder.Build();

if (builder.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Запуск приложения
app.UseHttpsRedirection();
app.MapControllers();
app.Run();