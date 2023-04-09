using AutoMapper;
using CollectCoRepositry.AutoMapper;
using CollectCoRepositry.Implementations.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Office.DataLayer;
using Office.DataLayer.Identity;
using OfficeRepositary.Configurations;
using OfficeRepositary.Repositaries;
using OfficeServices.Email;
using OfficeServices.Log;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Configuration;
using OfficeRepositary.Mapper.Implementation;
using OfficeRepositary.Mapper.Interface;
using OfficingEdge.Extentions;
using Office.DataLayer.data;
using OfficeRepositary.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();


// Add services to the container.

builder.Services.AddControllers()
	.AddJsonOptions(
		options =>
		{
			options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
			options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
		});
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
IMapper mapper = AutoMappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var configuration = new OfficeRepositary.Configurations.Configuration();

builder.Configuration.Bind("Configuration", configuration);
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IAuthentication, AuthenticationRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAuthenticationMapper, AuthenticationMapper>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<db_a9696f_officeContext>(options =>
	options.UseMySQL(connectionString));
builder.Services.AddAuthentication();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<db_a9696f_officeContext>()
	.AddDefaultTokenProviders();

//builder.Services.AddLogging(loggingBuilder =>
//				loggingBuilder.AddSerilog(dispose: true));
builder.Services.AddScoped<ILogService, LogService>();
var app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	
	app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();



