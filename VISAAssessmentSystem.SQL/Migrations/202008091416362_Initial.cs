namespace VISAAssessmentSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        Name = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        MobileNo1 = c.String(),
                        MobileNo2 = c.String(),
                        MaritalStatus = c.String(),
                        Age = c.Int(nullable: false),
                        NoOfChildren = c.Int(nullable: false),
                        Profession = c.String(),
                        Course = c.String(),
                        YearGraduated = c.String(),
                        Degree = c.String(),
                        DegreeStatus = c.String(),
                        DegreeResult = c.String(),
                        PresentJob = c.String(),
                        YearExperience = c.Int(nullable: false),
                        PresentAddress1 = c.String(),
                        PresentAddress2 = c.String(),
                        PhilAddress1 = c.String(),
                        PhilAddress2 = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Manager = c.String(),
                        ContactNo = c.String(),
                        Date = c.String(),
                        CountryId = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SchoolId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "CountryId", "dbo.Countries");
            DropIndex("dbo.Schools", new[] { "CountryId" });
            DropTable("dbo.Schools");
            DropTable("dbo.Countries");
            DropTable("dbo.Clients");
        }
    }
}
