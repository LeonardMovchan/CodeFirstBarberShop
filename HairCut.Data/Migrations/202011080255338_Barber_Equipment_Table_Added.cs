namespace HairCut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Barber_Equipment_Table_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarberEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        BarberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barbers", t => t.BarberId, cascadeDelete: true)
                .Index(t => t.BarberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BarberEquipments", "BarberId", "dbo.Barbers");
            DropIndex("dbo.BarberEquipments", new[] { "BarberId" });
            DropTable("dbo.BarberEquipments");
        }
    }
}
