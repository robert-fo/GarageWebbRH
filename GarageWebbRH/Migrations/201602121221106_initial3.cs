namespace GarageWebbRH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fordons", "Garage_garageId", "dbo.Garages");
            DropIndex("dbo.Fordons", new[] { "Garage_garageId" });
            RenameColumn(table: "dbo.Fordons", name: "Garage_garageId", newName: "garageId");
            AlterColumn("dbo.Fordons", "garageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fordons", "garageId");
            AddForeignKey("dbo.Fordons", "garageId", "dbo.Garages", "garageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fordons", "garageId", "dbo.Garages");
            DropIndex("dbo.Fordons", new[] { "garageId" });
            AlterColumn("dbo.Fordons", "garageId", c => c.Int());
            RenameColumn(table: "dbo.Fordons", name: "garageId", newName: "Garage_garageId");
            CreateIndex("dbo.Fordons", "Garage_garageId");
            AddForeignKey("dbo.Fordons", "Garage_garageId", "dbo.Garages", "garageId");
        }
    }
}
