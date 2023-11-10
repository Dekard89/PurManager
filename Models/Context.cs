using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PurchaseManager.Models
{
    public class Context: DbContext
    {
       public DbSet<Provider> providers { get; set; }

       public DbSet<Product> products { get; set; }

       public DbSet<Buyer> buyers { get; set; }

        private ConnectionString connectionString;


       public Context()
        {
           

            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=696");
        }

    }
}
