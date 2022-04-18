namespace CrewCall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Company = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            AddColumn("dbo.Event", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Event", "VenueId", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "EventDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Event", "EventTitle", c => c.String(nullable: false));
            AddColumn("dbo.Event", "IsPaid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Event", "IsTaxed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Event", "IsDirectDeposit", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venue", "VenueName", c => c.String(nullable: false));
            AddColumn("dbo.Venue", "VenueLocation", c => c.String(nullable: false));
            CreateIndex("dbo.Client", "ContactId");
            CreateIndex("dbo.Event", "VenueId");
            CreateIndex("dbo.Event", "ClientId");
            CreateIndex("dbo.Event", "ContactId");
            AddForeignKey("dbo.Event", "ClientId", "dbo.Client", "ClientId", cascadeDelete: true);
            AddForeignKey("dbo.Event", "ContactId", "dbo.Contact", "ContactId", cascadeDelete: true);
            AddForeignKey("dbo.Event", "VenueId", "dbo.Venue", "VenueId", cascadeDelete: true);
            AddForeignKey("dbo.Client", "ContactId", "dbo.Contact", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Event", "VenueId", "dbo.Venue");
            DropForeignKey("dbo.Event", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Event", "ClientId", "dbo.Client");
            DropIndex("dbo.Event", new[] { "ContactId" });
            DropIndex("dbo.Event", new[] { "ClientId" });
            DropIndex("dbo.Event", new[] { "VenueId" });
            DropIndex("dbo.Client", new[] { "ContactId" });
            DropColumn("dbo.Venue", "VenueLocation");
            DropColumn("dbo.Venue", "VenueName");
            DropColumn("dbo.Event", "IsDirectDeposit");
            DropColumn("dbo.Event", "IsTaxed");
            DropColumn("dbo.Event", "IsPaid");
            DropColumn("dbo.Event", "EventTitle");
            DropColumn("dbo.Event", "EventDate");
            DropColumn("dbo.Event", "ContactId");
            DropColumn("dbo.Event", "ClientId");
            DropColumn("dbo.Event", "VenueId");
            DropColumn("dbo.Event", "UserId");
            DropTable("dbo.Contact");
        }
    }
}
