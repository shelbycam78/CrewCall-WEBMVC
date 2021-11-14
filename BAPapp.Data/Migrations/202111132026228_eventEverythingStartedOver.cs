namespace BAPapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventEverythingStartedOver : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Event", newName: "EvenCreate");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EvenCreate", newName: "Event");
        }
    }
}
