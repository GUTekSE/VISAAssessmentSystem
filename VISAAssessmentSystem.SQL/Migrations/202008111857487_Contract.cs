namespace VISAAssessmentSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractNo = c.Int(nullable: false),
                        ContractDate = c.DateTime(nullable: false),
                        TargetDate = c.DateTime(nullable: false),
                        ContractFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrainingFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShowMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SchoolDeposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FileReview = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(),
                        Id = c.String(maxLength: 128),
                        ProgramId = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ContractNo)
                .ForeignKey("dbo.Clients", t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Contracts", "Id", "dbo.Clients");
            DropIndex("dbo.Contracts", new[] { "ProgramId" });
            DropIndex("dbo.Contracts", new[] { "Id" });
            DropTable("dbo.Contracts");
        }
    }
}
