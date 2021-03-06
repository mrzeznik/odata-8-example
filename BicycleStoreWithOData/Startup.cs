using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.OData;

using BicycleStore.Repositories;

namespace BicycleStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            // register OData service with models and setup available query features
            services.AddOData(opt =>
            {
                opt.AddModel("odata", EdmModelBuilder.GetEdmModel());
                opt.Filter().Select().OrderBy().SetMaxTop(50).Count();
            });
            services.AddTransient<IBicycleRepository, BicycleFakeRepository>();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OData 8.x Sample");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllers();
            });
        }
    }
}
