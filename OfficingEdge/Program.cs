using CollectCoRepositry.Implementations.Email;
using Microsoft.EntityFrameworkCore;
//using Office.DataLayer.Data;
//using OfficeRepositary.Interfaces;
using OfficeRepositary.Repositaries;
using OfficeServices.Email;
using OfficeServices.Log;
using Serilog;
using Serilog.Core;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
	

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(setup =>
{
	setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = "Weather Forecasts",
		Version = "v1"
	});
});
builder.Services.AddCors(o =>
{
	o.AddPolicy("CoresPolicy", builder =>
	builder.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());
});
//builder.Services.AddScoped<IAdminRepo, AdminRepo>();
//builder.Services.AddScoped<IMailService, MailService>();
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<officeContext>(options =>
//	options.UseMySQL(connectionString));

builder.Services.AddLogging(loggingBuilder =>
				loggingBuilder.AddSerilog(dispose: true));
builder.Services.AddScoped<ILogService, LogService>();
var app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	
	app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
app.Run();



