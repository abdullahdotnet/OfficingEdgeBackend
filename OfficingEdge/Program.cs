using Microsoft.EntityFrameworkCore;
using OfficingEdge.Data;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
	

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o =>
{
	o.AddPolicy("CoresPolicy", builder =>
	builder.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<officeContext>(options =>
	options.UseMySQL(connectionString));
Log.Logger = new LoggerConfiguration().WriteTo.File
	(
		path: "logs\\logs-.txt",
		outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}",
		rollingInterval: RollingInterval.Day,
		restrictedToMinimumLevel: LogEventLevel.Information

	).CreateLogger();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
app.Run();



