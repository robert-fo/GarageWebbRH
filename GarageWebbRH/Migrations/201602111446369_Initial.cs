namespace GarageWebbRH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fordons",
                c => new
                    {
                        regNr = c.String(nullable: false, maxLength: 128),
                        agare = c.String(),
                        pDatum = c.DateTime(nullable: false),
                        pPlatsNr = c.Int(nullable: false),
                        startDatum = c.DateTime(nullable: false),
                        slutDatum = c.DateTime(nullable: false),
                        Garage_garageId = c.Int(),
                    })
                .PrimaryKey(t => t.regNr)
                .ForeignKey("dbo.Garages", t => t.Garage_garageId)
                .Index(t => t.Garage_garageId);
            
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        garageId = c.Int(nullable: false, identity: true),
                        prisLiten = c.Double(nullable: false),
                        prisStor = c.Double(nullable: false),
                        antalPlatser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.garageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fordons", "Garage_garageId", "dbo.Garages");
            DropIndex("dbo.Fordons", new[] { "Garage_garageId" });
            DropTable("dbo.Garages");
            DropTable("dbo.Fordons");
        }
    }
}
