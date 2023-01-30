using APITask.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<APITaskContext>(opt => opt.UseInMemoryDatabase("taskDb"));
builder.Services.AddNpgsql<APITaskContext>(builder.Configuration.GetConnectionString("TaskDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] APITaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run("https://localhost:7157");

