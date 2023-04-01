using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarrierContext:DbContext
    {
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CarrierConnection")).EnableSensitiveDataLogging();

           

            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>().HasKey(c => c.CarrierId);
            modelBuilder.Entity<Order>().HasKey(c => c.OrderId);

            modelBuilder.Entity<CarrierConfiguration>().HasKey(c => c.CarrierConfigurationId);


            modelBuilder.Entity<Carrier>().HasData(new
            {
                CarrierName="Aras",
                CarrierIsActive = true,
                CarrierPlusDesiCost = 10,
                CarrierId=1,
                CarrierConfigurationId=1

            });
            modelBuilder.Entity<Order>().HasData(new
            {
                OrderId=1,
                OrderDesi = 10,
                OrderDate = DateTime.Now,
                OrderCarrierCost = 50.00m,
                CarrierId=1
            });
            modelBuilder.Entity<CarrierConfiguration>().HasData(new
            {
                CarrierConfigurationId=1,
                CarrierMaxDesi = 20,
                CarrierMinDesi = 2,
                CarrierCost = 40.00m,
                CarrierId=1
            });
        }
    }
}
