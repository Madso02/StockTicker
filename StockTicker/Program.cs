using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockTicker.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<MariaDbContext>(options => options
        .UseMySql(
            builder.Configuration.GetConnectionString("MariaDbConnectionString"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDbConnectionString"))
        )
    );

// Add services to the container.

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
