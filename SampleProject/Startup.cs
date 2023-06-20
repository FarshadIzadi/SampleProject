

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SampleProject.Data;

namespace SampleProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DbConnection")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());


        }




    }
}
