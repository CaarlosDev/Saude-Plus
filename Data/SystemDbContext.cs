using Microsoft.EntityFrameworkCore;
using SaudePlus.Data.Map;
using SaudePlus.Models;

namespace SaudePlus.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PersonModel> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
