using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MinimalAPI.Endpoints;
using MinimalAPI.Validation;


var customerEndpoint = new CustomerEndpoint();
var swaggerEndpoint = new SwaggerEndpoint();
var builder = WebApplication.CreateBuilder(args);
customerEndpoint.DefineServices(builder.Services);
swaggerEndpoint.DefineServices(builder.Services);
builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
//builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();

});

var app = builder.Build();

customerEndpoint.DefineEndpoints(app);
swaggerEndpoint.DefineEndpoints(app);
app.UseAuthentication();
app.UseAuthorization();

app.Run();



