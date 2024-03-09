namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkingOrders", "CarId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkingOrders", "CarId");
        }
    }
}
