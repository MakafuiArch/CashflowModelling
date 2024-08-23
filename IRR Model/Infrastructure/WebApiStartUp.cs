using IRR.Application.Interface;
using IRR.Application.Service;
using IRR.Domain.DBContext;
using IRR.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
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
            builder.Services.AddSingleton<IIRR, ArchViewIRRService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            await app.RunAsync();
        }
    }
}
