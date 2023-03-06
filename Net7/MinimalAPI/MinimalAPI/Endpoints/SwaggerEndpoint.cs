using Microsoft.OpenApi.Models;
using MinimalAPI.Models;

namespace MinimalAPI.Endpoints
{
    public class SwaggerEndpoint
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalAPI"));


        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo{Title = "MinimalAPI", Version = "v1"});
            });
        }
    }
}
