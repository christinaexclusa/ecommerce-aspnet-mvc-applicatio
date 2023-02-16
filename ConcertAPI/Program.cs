using ConcertAPI.Context;
using ConcertAPI.Repositories;
using ConcertAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


// Add services to the container.
builder.Services.AddDbContext<ConcertContext>();

builder.Services.AddScoped<IBandRepository, BandRepository>();
builder.Services.AddScoped<IConcertRepository, ConcertRepository>();
builder.Services.AddScoped<IMusicianRepository, MusicianRpository>();
builder.Services.AddScoped<IVenueRepository, VenueRepository>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
