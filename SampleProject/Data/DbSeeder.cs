using Microsoft.EntityFrameworkCore;
using SampleProject.Models;
using SQLitePCL;

namespace SampleProject.Data
{
    public static class DbSeeder
    {

        public static void SeedDatabase(AppDbContext context)
        {
            try {
                if (context.Database.GetPendingMigrations().Count() > 0)
                {
                    context.Database.Migrate();
                }
            }catch (Exception ex)
            {

            }

            if (context.Services.Any()) return;
            List<Services> services = new List<Services>()
            {
                new Services(){ServiceName = "Surgery",MinCapital = 5000,MaxCapital = 500000000,Rate= (decimal)0.0052},
                new Services(){ServiceName = "Dental",MinCapital = 4000,MaxCapital = 400000000,Rate= (decimal)0.0042},
                new Services(){ServiceName = "Hospitalization",MinCapital = 2000,MaxCapital = 200000000,Rate= (decimal)0.005m}
            };
            context.AddRangeAsync(services);
            context.SaveChangesAsync();
        }


    }
}
