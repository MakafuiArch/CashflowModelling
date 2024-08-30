using IRR.Application.Exceptions;
using IRR.Application.Interface;
using IRR.Application.Service;
using IRR.Domain.DBContext;
using IRR.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace IRR.Infrastructure
{
    public class WebApiStartUp : IStartUp
    {
       

        public async Task StartAsync(string[] args)
        {

            IConfigurationBuilder _configurationbuilder = new ConfigurationBuilder();
            
            IConfiguration c = _configurationbuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true).AddEnvironmentVariables().Build();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<IQueryService>(builder.Configuration.GetSection("ConnectionString"));
            builder.Services.AddSingleton<IQuery, IQueryService>();
            builder.Services.AddScoped<IIRR, ArchViewIRRService>();
            builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
            builder.Services.AddSingleton<IDataTest, TestDataRead>();
            builder.Services.AddExceptionHandler<IRRExceptionHandler>();
            builder.Services.AddExceptionHandler<SQLExceptionHandler>();
            builder.Services.AddResponseCaching();
            builder.Services.AddOutputCache(options =>
            {
                options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(5)));
                options.AddPolicy("Expire 1 min", builder => builder.Expire(TimeSpan.FromMinutes(1)));
            });


            //builder.Services.AddSingleton<IValidator<IRRInputs>, InputValidator>;

            // Add services to the container.

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RevoContext>(
                options => options.UseSqlServer(c.GetConnectionString("Revoreader"))
                );


            


            builder.Services.AddSwaggerGen(config =>

            {
                config.SwaggerDoc(

                    "v1",

                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Cashflow Modelling Service",
                        Description = "This Service Is To Model IRR For Any Give Retrocession Program"
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); 

                config.IncludeXmlComments(xmlPath);

            }

            );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                

                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
                    {
                        ["activated"] = false
                    };
                });


            }

            app.UseExceptionHandler(_ => { });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseResponseCaching();


            app.UseOutputCache();

            app.MapControllers();
            await app.RunAsync();
        }
    }
}
