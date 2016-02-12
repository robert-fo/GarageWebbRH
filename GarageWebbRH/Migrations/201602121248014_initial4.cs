namespace GarageWebbRH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Fordons");
            AddColumn("dbo.Fordons", "FordonId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Fordons", "regNr", c => c.String());
            AddPrimaryKey("dbo.Fordons", "FordonId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Fordons");
            AlterColumn("dbo.Fordons", "regNr", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Fordons", "FordonId");
            AddPrimaryKey("dbo.Fordons", "regNr");
        }
    }
}
