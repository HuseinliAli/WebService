namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExternalCars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ModelId = c.Int(nullable: false),
                        CarNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InternalCars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TechpassportSerialNumber = c.String(),
                        UserId = c.Guid(nullable: false),
                        ModelId = c.Int(nullable: false),
                        CarNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkingCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        PricePerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableSlots = c.Short(nullable: false),
                        TotalSlots = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkingOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ParkingCenterId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPriceWithTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        EmailAddress = c.String(),
                        Password = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.ParkingOrders");
            DropTable("dbo.ParkingCenters");
            DropTable("dbo.Models");
            DropTable("dbo.InternalCars");
            DropTable("dbo.ExternalCars");
            DropTable("dbo.Brands");
        }
    }
}
