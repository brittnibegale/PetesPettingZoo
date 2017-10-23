namespace PetesPettingZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcustomertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Double(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        OpenDaysId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OpenDays", t => t.OpenDaysId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.OpenDaysId)
                .Index(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Customers", "OpenDaysId", "dbo.OpenDays");
            DropIndex("dbo.Customers", new[] { "TicketId" });
            DropIndex("dbo.Customers", new[] { "OpenDaysId" });
            DropTable("dbo.Customers");
        }
    }
}
