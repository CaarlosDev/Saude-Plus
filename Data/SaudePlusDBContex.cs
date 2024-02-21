using Microsoft.EntityFrameworkCore;
using SaudePlus.Models;
namespace SaudePlus.Data

{
    public class SaudePlusDBContex : DbContext
    {
        public SaudePlusDBContex(DbContextOptions<SaudePlusDBContex> options)
            : base(options)
        {        
        }
        public DbSet<UserModels> Users { get; set; }
        public DbSet<PeopleModel> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
