namespace PetesPettingZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addticketdata : DbMigration
    {
        public override void Up()
        {
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (1,1)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (2,2)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (3,3)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (4,4)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (5,5)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (6,6)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (7,7)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (8,8)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (9,9)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (10,10)");
            Sql("SET Identity_Insert Tickets ON INSERT INTO Tickets (Id, TicketAmount) VALUES (11,11)");
        }

        public override void Down()
        {
        }
    }
}
