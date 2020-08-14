namespace VISAAssessmentSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        ProfessionId = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ProfessionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Professions");
        }
    }
}
