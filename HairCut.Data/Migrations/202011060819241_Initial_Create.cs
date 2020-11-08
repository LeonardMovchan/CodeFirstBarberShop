namespace HairCut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Int(nullable: false),
                        FullName = c.String(),
                        Phone = c.String(),
                        Expirience = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HairCutAppointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Phone = c.String(),
                        HairCutStyle = c.String(),
                        Date = c.DateTime(nullable: false),
                        BarberId = c.Int(nullable: false),
                        BarberShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barbers", t => t.BarberId, cascadeDelete: true)
                .ForeignKey("dbo.BarberShops", t => t.BarberShopId, cascadeDelete: true)
                .Index(t => t.BarberId)
                .Index(t => t.BarberShopId);
            
            CreateTable(
                "dbo.BarberShops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HairCutAppointments", "BarberShopId", "dbo.BarberShops");
            DropForeignKey("dbo.HairCutAppointments", "BarberId", "dbo.Barbers");
            DropIndex("dbo.HairCutAppointments", new[] { "BarberShopId" });
            DropIndex("dbo.HairCutAppointments", new[] { "BarberId" });
            DropTable("dbo.BarberShops");
            DropTable("dbo.HairCutAppointments");
            DropTable("dbo.Barbers");
        }
    }
}
