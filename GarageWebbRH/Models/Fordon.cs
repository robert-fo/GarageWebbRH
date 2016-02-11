using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageWebbRH.Models
{
    public enum fordonsTyp { Bil, MC, Buss, Lastbil }

    public class Fordon
    {
        [Key]
        public string regNr { get; set; }
        public string agare { get; set; }
        public fordonsTyp fTyp { get; set; }
        public DateTime? pDatum { get; set; } // ? Anger att datum kan vara null annars blir det fel vid generering
        public int pPlatsNr { get; set; }
        public DateTime? startDatum { get; set; }
        public DateTime? slutDatum { get; set; }
    }
}