using Microsoft.EntityFrameworkCore;

namespace TodoIpi.TaskLogic;

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDbContext<TaskContext>(options => { options.UseSqlite("Data Source=Todo.db"); });
		services.AddControllers();
		services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "TodoIpi.TaskLogic", Version = "v1" }); });
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoIpi.TaskLogic v1"));
		}

		app.UseHttpsRedirection();

		app.UseRouting();

		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}	
}