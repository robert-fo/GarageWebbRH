namespace GarageWebbRH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Fordons", new[] { "Garage_garageId1" });
            DropColumn("dbo.Fordons", "Garage_garageId");
            RenameColumn(table: "dbo.Fordons", name: "Garage_garageId1", newName: "Garage_garageId");
            AlterColumn("dbo.Fordons", "Garage_garageId", c => c.Int());
            CreateIndex("dbo.Fordons", "Garage_garageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Fordons", new[] { "Garage_garageId" });
            AlterColumn("dbo.Fordons", "Garage_garageId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Fordons", name: "Garage_garageId", newName: "Garage_garageId1");
            AddColumn("dbo.Fordons", "Garage_garageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fordons", "Garage_garageId1");
        }
    }
}
