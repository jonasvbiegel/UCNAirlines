using AirlineData.DatabaseLayer;
using APIService.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ISeatDB, SeatDB>();
builder.Services.AddScoped<ISeatLogic, SeatLogic>();
builder.Services.AddScoped<IBooking, BookingDatabaseAccess>();
builder.Services.AddScoped<IBookingLogic, BookingLogic>();
builder.Services.AddScoped<IAirport, AirportDatabaseAccess>();
builder.Services.AddScoped<IAirportLogic, AirportLogic>();
builder.Services.AddScoped<IPassengerDB, PassengerDB>();
builder.Services.AddScoped<IPassengerLogic, PassengerLogic>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFlightLogic, FlightLogic>();
builder.Services.AddScoped<IFlight, FlightDatabaseAccess>();

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
