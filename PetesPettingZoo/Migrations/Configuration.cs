
namespace PetesPettingZoo.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;

    internal sealed class Configuration : DbMigrationsConfiguration<PetesPettingZoo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetesPettingZoo.Models.ApplicationDbContext context)
        {
            context.Animals.AddOrUpdate(
                a => a.AnimalName,
                new Animal { AnimalName = "Lupe", AnimalType = "Alpaca", AtTheZoo = true },
                new Animal { AnimalName = "Pancho", AnimalType = "Moon Bear", AtTheZoo = false },
                new Animal { AnimalName = "Carlos", AnimalType = "Flamingo", AtTheZoo = true },
                new Animal { AnimalName = "Julio", AnimalType = "Emu", AtTheZoo = true },
                new Animal { AnimalName = "Mateo", AnimalType = "Dolphin", AtTheZoo = true },
                new Animal { AnimalName = "Rosa", AnimalType = "Meerkat", AtTheZoo = true },
                new Animal { AnimalName = "Luis", AnimalType = "Electric Eel", AtTheZoo = false },
                new Animal { AnimalName = "Efrain", AnimalType = "Kangaroo", AtTheZoo = true },
                new Animal { AnimalName = "Dolce", AnimalType = "Penguin", AtTheZoo = true },
                new Animal { AnimalName = "Edwardo", AnimalType = "Howler Monkey", AtTheZoo = false },
                new Animal { AnimalName = "Mattias", AnimalType = "Tiger Shark", AtTheZoo = true },
                new Animal { AnimalName = "Rolanda", AnimalType = "Cicada", AtTheZoo = true },
                new Animal { AnimalName = "Rico", AnimalType = "Gazelle", AtTheZoo = true },
                new Animal { AnimalName = "Maria", AnimalType = "Macaque", AtTheZoo = true },
                new Animal { AnimalName = "Cristiano", AnimalType = "Iguana", AtTheZoo = false },
                new Animal { AnimalName = "Juan", AnimalType = "Flying Squirrel", AtTheZoo = true }
           );
            context.Days.AddOrUpdate(
                b => b.Day,
                new OpenDays { Day = DateTime.Parse("10/28/2017") },
                new OpenDays { Day = DateTime.Parse("10/29/17") }
                );
        }

        public class MailJet
        {
            SmtpClient client = new SmtpClient("in.mailjet.com ")
            {
                Credentials = new NetworkCredential("", ""),
                EnableSsl = true
            };
        }
    }
}