using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageWebbRH.DataAccessLayer
{
    public class ItemContext : DbContext
    {
        public ItemContext() : base("DefaultConnection") { }

        public DbSet<Models.Fordon> Fordon { get; set; }
        public DbSet<Models.Fordonstyp> Fordonstyp { get; set; }
        public DbSet<Models.Agare> Agare { get; set; }
    }
}