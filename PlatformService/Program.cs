namespace PlatformService
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PlatformService.Data;
    using PlatformService.SyncDataServices.Http;

    public static class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsProduction())
            {
                Console.WriteLine("--> Using MSSQL Server Db");
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("PlatformConn"))
                );
            }
            else
            {
                Console.WriteLine("--> Using InMem Db");
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("InMemory")
                );
            }

            builder.Services.AddControllers();

            builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
            builder.Services.AddSwaggerGen();

            Console.WriteLine(
                $"--> CommandService Endpoint {builder.Configuration["CommandService"]}"
            );

            var app = builder.Build();

            PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.Run();
        }

        #endregion
    }
}
