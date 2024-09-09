
using LossPayment.Application.Service;
using LossPayment.Application.Interface;
using Microsoft.Extensions.Caching.Memory;


namespace LossPayment.Infrastracture
{
    public class StartUp : IStartup
    {
        public void Configure(IApplicationBuilder app)
        {

            var applicationService = app.Build();


            throw new NotImplementedException();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSingleton<IQuery, QueryService>();
            services.AddScoped<IPaidLoss, ProportionalPaidLoss>();
            services.AddSingleton<IMemoryCache, MemoryCache>();


            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyMethod());
            });

            throw new NotImplementedException();
        }


        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { }
        }


    }
}
