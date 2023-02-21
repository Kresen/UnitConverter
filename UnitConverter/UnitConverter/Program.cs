using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitConverter.Api.Data;
using UnitConverter.Api.Repository;
using UnitConverter.Api.Repository.Interfaces;
using UnitConverter.Api.Services;
using UnitConverter.Api.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var optionsBuilder = new DbContextOptionsBuilder<ConversionRateDbContext>();
builder.Services.AddScoped<IConversionRepository,ConversionRepository> ();
builder.Services.AddScoped<IConversionService,ConversionService>();

builder.Services.AddDbContext<ConversionRateDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));


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



// omitted

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ConversionRateDbContext>();
    context.Database.Migrate();
}

app.Run();
