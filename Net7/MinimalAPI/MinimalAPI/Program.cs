using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CustomerRepository>();
var app = builder.Build();

app.MapGet("/customers", ([FromServices] CustomerRepository repo) => repo.GetAll());

app.MapGet("/customers/{id}", ([FromServices] CustomerRepository repo, Guid id) =>
{
    var customer = repo.GetById(id);
    return  customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.MapPost("/customers/{id}", ([FromServices] CustomerRepository repo, Customer customer) =>
{
    repo.Create(customer);
    return Results.Created($"/customers/{customer.Id}", customer);
});

app.MapPut("/customers/{id}", ([FromServices] CustomerRepository repo, Guid id, Customer updatedCustomer) =>
{
    var customer = repo.GetById(id);
    if(customer is not null) return Results.NotFound();

    repo.Update(updatedCustomer);
    return Results.Ok(updatedCustomer);
});

app.MapDelete("/customers/{id}", ([FromServices] CustomerRepository repo, Guid id) => repo.Delete(id) ? Results.Ok() : Results.NotFound());

app.Run();



