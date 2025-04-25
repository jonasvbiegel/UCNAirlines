using AirlineData.DatabaseLayer;
using FlightRestService.BusinessLogicLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IFlightData, FlightDataLogic>();
builder.Services.AddSingleton<IFlight, FlightDatabaseAccess>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
