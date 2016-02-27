namespace Motd.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        LogTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(nullable: false),
                        IsFbUser = c.Boolean(nullable: false),
                        Campaign_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .Index(t => t.Campaign_Id);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MOTD = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TimeToClick = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        IsEmpty = c.Boolean(nullable: false),
                        Prize_Id = c.Int(),
                        Campaign_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prizes", t => t.Prize_Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .Index(t => t.Prize_Id)
                .Index(t => t.Campaign_Id);
            
            CreateTable(
                "dbo.Prizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                        IsWon = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CampaignLogItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        LogTime = c.DateTime(nullable: false),
                        isCorrectMotd = c.Boolean(nullable: false),
                        isWonAPrize = c.Boolean(nullable: false),
                        Campaign_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Campaign_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminLogItems", "Id", "dbo.Users");
            DropForeignKey("dbo.CampaignLogItems", "Id", "dbo.Users");
            DropForeignKey("dbo.CampaignLogItems", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Boxes", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Boxes", "Prize_Id", "dbo.Prizes");
            DropForeignKey("dbo.Users", "Campaign_Id", "dbo.Campaigns");
            DropIndex("dbo.CampaignLogItems", new[] { "Campaign_Id" });
            DropIndex("dbo.CampaignLogItems", new[] { "Id" });
            DropIndex("dbo.Boxes", new[] { "Campaign_Id" });
            DropIndex("dbo.Boxes", new[] { "Prize_Id" });
            DropIndex("dbo.Users", new[] { "Campaign_Id" });
            DropIndex("dbo.AdminLogItems", new[] { "Id" });
            DropTable("dbo.CampaignLogItems");
            DropTable("dbo.Prizes");
            DropTable("dbo.Boxes");
            DropTable("dbo.Campaigns");
            DropTable("dbo.Users");
            DropTable("dbo.AdminLogItems");
        }
    }
}
