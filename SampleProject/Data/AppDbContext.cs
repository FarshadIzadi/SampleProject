using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

namespace SampleProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<SoldInsurance> SoldInsurances { get; set; }
    }
}
