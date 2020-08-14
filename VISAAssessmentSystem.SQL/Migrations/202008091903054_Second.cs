namespace VISAAssessmentSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schools", "CountryId", "dbo.Countries");
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.Countries", "CountryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Countries", "CountryId");
            AddForeignKey("dbo.Schools", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "CountryId", "dbo.Countries");
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.Countries", "CountryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Countries", "CountryId");
            AddForeignKey("dbo.Schools", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
    }
}
