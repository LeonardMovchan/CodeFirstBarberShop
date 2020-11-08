namespace HairCut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Barbers_BarberShop_Connection_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barbers", "BarberShopId", c => c.Int(nullable: false));
            CreateIndex("dbo.Barbers", "BarberShopId");
            AddForeignKey("dbo.Barbers", "BarberShopId", "dbo.BarberShops", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barbers", "BarberShopId", "dbo.BarberShops");
            DropIndex("dbo.Barbers", new[] { "BarberShopId" });
            DropColumn("dbo.Barbers", "BarberShopId");
        }
    }
}
