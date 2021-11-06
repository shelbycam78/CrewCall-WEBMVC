namespace BAPapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class EventClassUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "EventDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Event", "EventTitle", c => c.String(nullable: false));
            DropColumn("dbo.Event", "Date");
            DropColumn("dbo.Event", "Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Event", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Event", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Event", "EventTitle");
            DropColumn("dbo.Event", "EventDate");
        }
    }
}
