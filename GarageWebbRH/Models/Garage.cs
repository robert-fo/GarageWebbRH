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
        public int garageId { get; set; }
        public double prisLiten { get; set; }
        public double prisStor { get; set; }
        public int antalPlatser { get; set; }
        public List<Fordon> pPlatser { get; set; }
    }
}