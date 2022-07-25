namespace IotShipmentProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SerialNumber = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        IdentityNumber = c.String(nullable: false),
                        DrivingLicenceNumber = c.String(nullable: false),
                        DrivingLicenceType = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IotCarId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        ShipmentNumber = c.String(nullable: false),
                        Product = c.String(nullable: false),
                        ShipmentState = c.Int(nullable: false),
                        StartPoint = c.String(),
                        EndPoint = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.IotCars", t => t.IotCarId, cascadeDelete: true)
                .Index(t => t.IotCarId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.IotCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        PlateNumber = c.String(nullable: false),
                        VehicleType = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "IotCarId", "dbo.IotCars");
            DropForeignKey("dbo.IotCars", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Shipments", "DriverId", "dbo.Drivers");
            DropIndex("dbo.IotCars", new[] { "DeviceId" });
            DropIndex("dbo.Shipments", new[] { "DriverId" });
            DropIndex("dbo.Shipments", new[] { "IotCarId" });
            DropTable("dbo.IotCars");
            DropTable("dbo.Shipments");
            DropTable("dbo.Drivers");
            DropTable("dbo.Devices");
        }
    }
}
