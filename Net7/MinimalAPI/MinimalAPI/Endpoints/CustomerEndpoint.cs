using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;

namespace MinimalAPI.Endpoints
{
    public class CustomerEndpoint
    {
        // guid example: ab375ba9-7739-444e-8e46-b19fc10f1c1f
        public void DefineEndpoints(WebApplication app)
        {
            //Trick to show JSON
            app.MapGet("/customers", GetAllCustomers).Produces<Customer>().AllowAnonymous();

            app.MapGet("/customers/{id}", GetCustomerById);

            app.MapPost("/customers/{id}", CreateCustomer).AllowAnonymous();

            app.MapPut("/customers/{id}",  UpdateCustomer);

            app.MapDelete("/customers/{id}", DeleteCustomer);

        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }

        internal IResult GetCustomerById(ICustomerRepository repo, Guid id)
        {
            var customer = repo.GetById(id);
            return customer is not null ? Results.Ok(customer) : Results.NotFound();
        }
        
        internal IResult CreateCustomer(ICustomerRepository repo, IValidator<Customer> validator, Customer customer)
        {
            var validationResult = validator.Validate(customer);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => new { errors = x.ErrorMessage });
                return Results.BadRequest(errors);
            }
            repo.Create(customer);
            return Results.Created($"/customers/{customer.Id}", customer);
        }
        
        internal IResult UpdateCustomer(ICustomerRepository repo, Guid id, Customer updatedCustomer)
        {
            var customer = repo.GetById(id);
            if (customer is not null) return Results.NotFound();

            repo.Update(updatedCustomer);
            return Results.Ok(updatedCustomer);
        }

        internal IResult DeleteCustomer(ICustomerRepository repo, Guid id) =>
            repo.Delete(id) ? Results.Ok() : Results.NotFound();

        internal IResult GetAllCustomers(ICustomerRepository repo) => Results.Ok(repo.GetAll());
        
    }
}
