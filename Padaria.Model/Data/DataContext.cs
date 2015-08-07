using System.Data.Entity;
using System.Configuration;
using Padaria.Repository.Entities;

namespace Padaria.Repository.Data
{

    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["CakeHouse"].ConnectionString)
        {
            Database.SetInitializer<DataContext>(null);
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<TypeOfRegistration> TypeOfRegistration { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<PayBox> PayBox { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Controls> Controls { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
