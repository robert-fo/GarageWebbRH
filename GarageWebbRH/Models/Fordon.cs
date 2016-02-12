using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageWebbRH.Models
{
    public enum fordonsTyp { Bil, MC, Buss, Lastbil }

    public class Fordon
    {
        [Key]
        public int FordonId { get; set; }
        public string regNr { get; set; }
        public string agare { get; set; }
        public fordonsTyp fTyp { get; set; }
        public DateTime? pDatum { get; set; } // ? Anger att datum kan vara null annars blir det fel vid generering
        public int pPlatsNr { get; set; }
        public DateTime? startDatum { get; set; }
        public DateTime? slutDatum { get; set; }
        public int garageId { get; set; } // FK måste ha exakt samma namn som egenskapen i klassen den är beroende av, annars måste ForeignKey användas för arr specificera annat namn.
    }
}