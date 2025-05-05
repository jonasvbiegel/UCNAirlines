using AirlineData.DatabaseLayer;
using APIService.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ISeatDB, SeatDB>();
builder.Services.AddSingleton<ISeatLogic, SeatLogic>();

builder.Services.AddSingleton<IPassengerDB, PassengerDB>();
builder.Services.AddSingleton<IPassengerLogic, PassengerLogic>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFlightLogic, FlightLogic>();
builder.Services.AddSingleton<IFlight, FlightDatabaseAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
