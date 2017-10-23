namespace PetesPettingZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanimaltable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(),
                        AnimalType = c.String(),
                        AtTheZoo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animals");
        }
    }
}
