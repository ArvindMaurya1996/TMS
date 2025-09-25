using Microsoft.EntityFrameworkCore;
using TMS.Core.Models;


namespace TMS.Core.DB
{
    public class TMSDbContext : DbContext
    {

        public TMSDbContext(DbContextOptions<TMSDbContext> options):base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase(databaseName: "TMSDb");
            
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<Models.Task>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }


    }
}
