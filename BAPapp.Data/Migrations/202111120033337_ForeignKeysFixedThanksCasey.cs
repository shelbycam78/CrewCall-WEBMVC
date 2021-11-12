namespace BAPapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysFixedThanksCasey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Event");
            CreateTable(
                "dbo.Crewer",
                c => new
                    {
                        CrewerId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CrewerId);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        VenueId = c.String(nullable: false, maxLength: 128),
                        VenueName = c.String(nullable: false),
                        VenueLocation = c.String(nullable: false),
                        PointOfContact = c.String(),
                    })
                .PrimaryKey(t => t.VenueId);
            
            CreateTable(
                "dbo.VenueCrewer",
                c => new
                    {
                        Venue_VenueId = c.String(nullable: false, maxLength: 128),
                        Crewer_CrewerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Venue_VenueId, t.Crewer_CrewerId })
                .ForeignKey("dbo.Venue", t => t.Venue_VenueId, cascadeDelete: true)
                .ForeignKey("dbo.Crewer", t => t.Crewer_CrewerId, cascadeDelete: true)
                .Index(t => t.Venue_VenueId)
                .Index(t => t.Crewer_CrewerId);
            
            AlterColumn("dbo.Event", "EventId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Event", "VenueId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Event", "CrewerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Event", "EventId");
            CreateIndex("dbo.Event", "VenueId");
            CreateIndex("dbo.Event", "CrewerId");
            AddForeignKey("dbo.Event", "CrewerId", "dbo.Crewer", "CrewerId", cascadeDelete: true);
            AddForeignKey("dbo.Event", "VenueId", "dbo.Venue", "VenueId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "VenueId", "dbo.Venue");
            DropForeignKey("dbo.VenueCrewer", "Crewer_CrewerId", "dbo.Crewer");
            DropForeignKey("dbo.VenueCrewer", "Venue_VenueId", "dbo.Venue");
            DropForeignKey("dbo.Event", "CrewerId", "dbo.Crewer");
            DropIndex("dbo.VenueCrewer", new[] { "Crewer_CrewerId" });
            DropIndex("dbo.VenueCrewer", new[] { "Venue_VenueId" });
            DropIndex("dbo.Event", new[] { "CrewerId" });
            DropIndex("dbo.Event", new[] { "VenueId" });
            DropPrimaryKey("dbo.Event");
            AlterColumn("dbo.Event", "CrewerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Event", "VenueId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Event", "EventId", c => c.Guid(nullable: false));
            DropTable("dbo.VenueCrewer");
            DropTable("dbo.Venue");
            DropTable("dbo.Crewer");
            AddPrimaryKey("dbo.Event", "EventId");
        }
    }
}
