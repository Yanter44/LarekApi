using LarekApi.Entityes;
using Microsoft.EntityFrameworkCore;

namespace LarekApi
{
    public class ApplicationDb : DbContext
    {

      public  DbSet<Category> Categories { get; set; }

      public DbSet<Product> Products { get; set; }
      public DbSet<OrderCustomer> Orders { get; set; }

        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {
            
            Database.EnsureCreated();
            Database.OpenConnection();
        
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCustomer>()
               .ToTable("Orders"); 
        }
    }
}
