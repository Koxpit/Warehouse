using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.Database
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
