namespace VISAAssessmentSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Schools");
            AlterColumn("dbo.Schools", "SchoolId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Schools", "SchoolId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Schools");
            AlterColumn("dbo.Schools", "SchoolId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Schools", "SchoolId");
        }
    }
}
