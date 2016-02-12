using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageWebbRH.Models
{
    public class Garage
    {
        [Key]
        public int garageId { get; set; } // Vill man ändra nyckelnamn kommer man bli tvungen att ändra till nytta db namn i web.config connectionstring med.
        public double prisLiten { get; set; }
        public double prisStor { get; set; }
        public int antalPlatser { get; set; }
        public virtual ICollection<Fordon> pPlatser { get; set; }
    }
}