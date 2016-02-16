using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using GarageWebbRH.Repository;

namespace GarageWebbRH.Models
{
    public class Fordon
    {
        [Key]
        public int FordonId { get; set; }
        [DisplayName("Reg Nr")]
        public string regNr { get; set; }
        [DisplayName("Ägare")]
        public string agare { get; set; }
        [DisplayName("Fordons Typ")]
        public fordonsTyp fTyp { get; set; }
        [DisplayName("Parkeringsdatum")]
        public DateTime? pDatum { get; set; } // ? Anger att datum kan vara null annars blir det fel vid generering
        [DisplayName("Plats Nr")]
        public int pPlatsNr { get; set; }
        [DisplayName("Startdatum")]
        public DateTime? startDatum { get; set; }
        [DisplayName("Slutdatum")]
        public DateTime? slutDatum { get; set; }
        [DisplayName("Garage Id")]
        public int garageId { get; set; } // FK måste ha exakt samma namn som egenskapen i klassen den är beroende av, annars måste ForeignKey användas för arr specificera annat namn.
    }
}