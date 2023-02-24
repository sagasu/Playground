using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CustomerRepository>();
var app = builder.Build();

app.MapGet("/customers", ([FromServices] CustomerRepository repo) => repo.GetAll());

app.Run();



