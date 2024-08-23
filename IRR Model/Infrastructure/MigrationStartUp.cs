using IRR.Infrastructure.Interface;
using IRR.Domain.DBContext;
using Microsoft.EntityFrameworkCore;



namespace IRR.Infrastructure
{
    public class MigrationStartUp : IStartUp
    {
        public async Task StartAsync(string[] args)
        {

            ConfigurationBuilder configurationBuilder = new();
            IConfiguration c = configurationBuilder.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RevoContext>((sp, o) =>
            {
                o.UseSqlServer(builder.Configuration.GetConnectionString("Revoreader"));
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            
            using var scope = app.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<RevoContext>().Database.MigrateAsync();

        }

    }
}
