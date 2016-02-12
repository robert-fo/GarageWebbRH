namespace GarageWebbRH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fordons", "Garage_garageId", "dbo.Garages");
            DropIndex("dbo.Fordons", new[] { "Garage_garageId" });
            AddColumn("dbo.Fordons", "Garage_garageId1", c => c.Int());
            AlterColumn("dbo.Fordons", "Garage_garageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fordons", "Garage_garageId1");
            AddForeignKey("dbo.Fordons", "Garage_garageId1", "dbo.Garages", "garageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fordons", "Garage_garageId1", "dbo.Garages");
            DropIndex("dbo.Fordons", new[] { "Garage_garageId1" });
            AlterColumn("dbo.Fordons", "Garage_garageId", c => c.Int());
            DropColumn("dbo.Fordons", "Garage_garageId1");
            CreateIndex("dbo.Fordons", "Garage_garageId");
            AddForeignKey("dbo.Fordons", "Garage_garageId", "dbo.Garages", "garageId");
        }
    }
}
