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
            //context.Garage.AddOrUpdate(
            //        new Garage
            //        {
            //            antalPlatser = 36,
            //            pPlatser = new List<Fordon> { 
            //           new Fordon { regNr = "ABC123", agare = " Kalle", fTyp = fordonsTyp.Bil, pDatum = DateTime.Now, pPlatsNr = 0, },
            //           new Fordon { regNr = "BCD234", agare = " Kalle", fTyp = fordonsTyp.Bil, pDatum = DateTime.Now, pPlatsNr = 0 },
            //           new Fordon { regNr = "CDE345", agare = " Kalle", fTyp = fordonsTyp.Bil, pDatum = DateTime.Now, pPlatsNr = 0 }
            //        }
            //        });

            context.Fordonstyp.AddOrUpdate(
                    new Fordonstyp { Namn = "Bil", TimPris = 12 },
                    new Fordonstyp { Namn = "MC", TimPris = 6 },
                    new Fordonstyp { Namn = "Buss", TimPris = 48 },
                    new Fordonstyp { Namn = "Lastbil", TimPris = 60 }
                );

            context.Agare.AddOrUpdate(
                    new Agare { Fnamn = "Kalle", Enamn = "Kula", TelefonNr = "123456" },
                    new Agare { Fnamn = "Ulla", Enamn = "Ullson", TelefonNr = "123456" },
                    new Agare { Fnamn = "Sanna", Enamn = "Sannson", TelefonNr = "123456" },
                    new Agare { Fnamn = "Svullo", Enamn = "Svullson", TelefonNr = "123456" }
                );

            context.Fordon.AddOrUpdate(
                    new Fordon { RegNr = "ABC123", AgareID = 11, FtypID = 1, Pdatum = DateTime.Now, PplatsNr = 1, },
                    new Fordon { RegNr = "BCD234", AgareID = 12, FtypID = 1, Pdatum = DateTime.Now, PplatsNr = 2 },
                    new Fordon { RegNr = "CDE345", AgareID = 13, FtypID = 1, Pdatum = DateTime.Now, PplatsNr = 3 }
                );
        }
    }
}
