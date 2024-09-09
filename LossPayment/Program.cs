using LossPayment.Application.Interface;
using LossPayment.Application.Service;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IQuery, QueryService>();
builder.Services.AddScoped<IPaidLoss, ProportionalPaidLoss>();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

builder.Services.AddSwaggerGen(config =>

{
    config.SwaggerDoc(

        "v1",

        new OpenApiInfo
        {
            Version = "v1",
            Title = "Loss Payment Service",
            Description = "Service is to return Paid Loss Schedule"
        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    //config.IncludeXmlComments(xmlPath);

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

app.Run();
