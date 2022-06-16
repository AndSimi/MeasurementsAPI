using MeasurementsAPI.Models;
using MeasurementsAPI.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dependency Injection
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IMeasurementServices, MeasurementService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
