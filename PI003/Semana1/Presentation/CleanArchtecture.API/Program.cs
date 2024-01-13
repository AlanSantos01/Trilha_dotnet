using Microsoft.AspNetCore.Builder;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence;
using CleanArchitecture.Application.Services;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);



builder.Services.configurePersistenceApp(builder.Configuration);

builder.Services.ConfigureApplicationApp();


builder.Services.AddControllers();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

CreateDatabase(app);

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();



app.Run();

static void CreateDatabase(WebApplication app){
    var serviceScope = app.Services.CreateScope();
    var dataContex =serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContex?.Database.EnsureCreated();

}