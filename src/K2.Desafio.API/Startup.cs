using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using K2.Desafio.API.Configuration;
using K2.Desafio.Application.Configuration.Validation;
using K2.Desafio.API.SeedWork;
using Microsoft.Extensions.Hosting;
using MediatR;
using System;
using K2.Desafio.Application.Accounting.GitHub;
using System.Reflection;
using K2.Desafio.Application.Accounting.GetInterestRate;
using K2.Desafio.Application.Accounting.GetCalculateInterest;

[assembly: UserSecretsId("5b16cf30-bdb1-47be-8300-4785b2633903")]
namespace K2.Desafio.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            {
                services.AddControllers();

                services.AddMemoryCache();

                services.AddMediatR(typeof(GetGitHubQuery).GetTypeInfo().Assembly);

                services.AddMediatR(typeof(GetInterestRateQuery).GetTypeInfo().Assembly);

                services.AddMediatR(typeof(GetCalculateInterestQuery).GetTypeInfo().Assembly);


                services.AddSwaggerDocumentation();

                services.AddProblemDetails(x =>
                {
                    x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                });
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseAuthentication();
            app.UseSwaggerDocumentation();
        }
    }
}
