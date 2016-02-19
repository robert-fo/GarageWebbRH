namespace GarageWebbRH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agares",
                c => new
                    {
                        AgareId = c.Int(nullable: false, identity: true),
                        Fnamn = c.String(),
                        Enamn = c.String(),
                        TelefonNr = c.String(),
                    })
                .PrimaryKey(t => t.AgareId);
            
            CreateTable(
                "dbo.Fordons",
                c => new
                    {
                        FordonId = c.Int(nullable: false, identity: true),
                        RegNr = c.String(),
                        AgareID = c.Int(nullable: false),
                        FtypID = c.Int(nullable: false),
                        Pdatum = c.DateTime(),
                        PplatsNr = c.Int(nullable: false),
                        StartDatum = c.DateTime(),
                        SlutDatum = c.DateTime(),
                    })
                .PrimaryKey(t => t.FordonId)
                .ForeignKey("dbo.Agares", t => t.AgareID, cascadeDelete: true)
                .ForeignKey("dbo.Fordonstyps", t => t.FtypID, cascadeDelete: true)
                .Index(t => t.AgareID)
                .Index(t => t.FtypID);
            
            CreateTable(
                "dbo.Fordonstyps",
                c => new
                    {
                        FtypId = c.Int(nullable: false, identity: true),
                        Namn = c.String(),
                        TimPris = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FtypId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fordons", "FtypID", "dbo.Fordonstyps");
            DropForeignKey("dbo.Fordons", "AgareID", "dbo.Agares");
            DropIndex("dbo.Fordons", new[] { "FtypID" });
            DropIndex("dbo.Fordons", new[] { "AgareID" });
            DropTable("dbo.Fordonstyps");
            DropTable("dbo.Fordons");
            DropTable("dbo.Agares");
        }
    }
}
