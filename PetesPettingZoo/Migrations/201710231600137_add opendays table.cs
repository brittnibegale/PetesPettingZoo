namespace PetesPettingZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addopendaystable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpenDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpenDays");
        }
    }
}
