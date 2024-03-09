using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebService.Data.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("ParkingDb")
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ParkingCenter> ParkingCenters { get; set; }
        public DbSet<ParkingOrder> ParkingOrders { get; set; }
        public DbSet<InternalCar> InternalCars { get; set; }
        public DbSet<ExternalCar> ExternalCars { get; set; }
    }
}