namespace PetesPettingZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedemployeemodel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Sex = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
