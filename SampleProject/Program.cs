using SampleProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace SampleProject
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger < Program >>();

            try
            {
                DbSeeder.SeedDatabase(context);
            }
            catch(Exception ex) {
                logger.LogError(ex, "خطا در بارگذاری پایگاه داده. ");
            }
                
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) => 
            Host.CreateDefaultBuilder(args).
            ConfigureWebHostDefaults(webBuilder => 
            webBuilder.UseStartup<Startup>()
        );

    }
}