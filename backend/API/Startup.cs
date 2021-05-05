using InModeration.Backend.API.Data;
using InModeration.Backend.API.Data.Repositories;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace InModeration.Backend.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning(
                config =>
                {
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.AssumeDefaultVersionWhenUnspecified = true;
                }
           );

            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<ISiteRuleRepository, SiteRuleRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<ISiteRuleService, SiteRuleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(
                errorApp =>
                {
                    errorApp.Run(
                        async context =>
                        {
                            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                            var exception = exceptionHandlerPathFeature.Error;

                            logger.LogError(exception.ToString());

                            var message = "Server error";
                            var code = 500;
                            if (exception is HttpException httpException)
                            {
                                code = (int)httpException.Code;
                                message = httpException.Message ?? message;
                            }

                            context.Response.StatusCode = code;
                            await context.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes(message));

                        }
                    );
                }
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
