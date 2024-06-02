using ApiItaliaMi.Models;
using ApiItaliaMi.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ApiItaliaMi.Data
{
    public class ItaliaMiDataContext : DbContext
    {

        private const string connString = "Server = localhost,1433; Database=ItaliaMi;User ID = sa; Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
        public DbSet<Cittizenship> Cittizenships { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CittizenshipMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new PassportMap());

        }

    }
}
