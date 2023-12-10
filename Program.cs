using SeventhServers.Installers;
using SeventhServers.Infrastructure.Data;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatr();
builder.Services.AddDatabaseContext(builder.Configuration.GetConnectionString("Postgres"));
builder.Services.AddMessaging(builder.Configuration.GetConnectionString("RabbitMq"));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
