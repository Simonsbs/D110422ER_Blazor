using Microsoft.EntityFrameworkCore;
using MyShop.API.Controllers;
using MyShop.Shared;

namespace MyShopAPI.Contexts {
    /// <summary>
    /// 
    /// </summary>
    public class MyShopContext : DbContext {
        public MyShopContext(DbContextOptions<MyShopContext> options)
            : base(options) {
        }

        public DbSet<Employee> Employees { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee() { ID = 1, FirstName = "Simon", LastName = "Stirling", Image = "https://picsum.photos/id/237/300/300" },
                new Employee() { ID = 2, FirstName = "Bob", LastName = "Smith", Image = "https://picsum.photos/id/238/300/300" },
                new Employee() { ID = 3, FirstName = "Jane", LastName = "Doe", Image = "https://picsum.photos/id/239/300/300" });
        }
    }
}
