using System.Reflection;
using API.Extensions;
using API.Helpers;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Persistency;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
					.ReadFrom.Configuration(builder.Configuration)
					.Enrich.FromLogContext()
					.CreateLogger();

//builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.ConfigureRateLimiting();
builder.Services.AddAplicacionServices();
builder.Services.ConfigureApiVersioning();
builder.Services.AddJwt(builder.Configuration);

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var loggerFactory = services.GetRequiredService<ILoggerFactory>();
	try
	{
		var context = services.GetRequiredService<ApiDbContext>();
		await context.Database.MigrateAsync();
	}
	catch (Exception ex)
	{
		var _logger = loggerFactory.CreateLogger<Program>();
		_logger.LogError(ex, "An exception occurred during migration");
	}
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseIpRateLimiting();
app.MapControllers();

app.Run();
