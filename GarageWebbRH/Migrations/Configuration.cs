namespace GarageWebbRH.Migrations
{
    using GarageWebbRH.Models;
    using GarageWebbRH.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageWebbRH.DataAccessLayer.ItemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GarageWebbRH.DataAccessLayer.ItemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Garage.AddOrUpdate(
                    new Garage
                    {
                        antalPlatser = 36,
                        prisLiten = 12,
                        prisStor = 30,
                        pPlatser = new List<Fordon> { 
                       new Fordon { regNr = "ABC123", agare = " Kalle", fTyp = fordonsTyp.Bil, pDatum = DateTime.Now, pPlatsNr = 0, },
                       new Fordon { regNr = "BCD234", agare = " Kalle", fTyp = fordonsTyp.Bil, pDatum = DateTime.Now, pPlatsNr = 0 },
                       new Fordon { regNr = "CDE345", agare = " Kalle", fTyp = fordonsTyp.Bil, pDatum = DateTime.Now, pPlatsNr = 0 }
                    }
                    });
        }
    }
}
