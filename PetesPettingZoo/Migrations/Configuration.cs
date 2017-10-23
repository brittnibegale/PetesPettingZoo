
namespace PetesPettingZoo.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                new Animal { AnimalName = "Carlos", AnimalType = "Flamingo", AtTheZoo = true }
           );
            context.Days.AddOrUpdate(
                b => b.Day,
                new OpenDays {Day = DateTime.Parse("10/28/2017") },
                new OpenDays { Day = DateTime.Parse("10/29/17")}
                );
        }
    }
}

