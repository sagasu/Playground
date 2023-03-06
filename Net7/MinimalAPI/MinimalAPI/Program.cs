using MinimalAPI.Endpoints;
using MinimalAPI.Models;


var customerEndpoint = new CustomerEndpoint();
var swaggerEndpoint = new SwaggerEndpoint();
var builder = WebApplication.CreateBuilder(args);
customerEndpoint.DefineServices(builder.Services);
swaggerEndpoint.DefineServices(builder.Services);

var app = builder.Build();

customerEndpoint.DefineEndpoints(app);
swaggerEndpoint.DefineEndpoints(app);


app.Run();



