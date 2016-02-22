using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using GarageWebbRH.Repository;
using System.Collections;

namespace GarageWebbRH.Models
{
    public class Fordon
    {
        [Key]
        public int FordonId { get; set; }
        [DisplayName("Reg Nr")]
        public string RegNr { get; set; }
        [DisplayName("Ägare Id")]
        public int AgareID { get; set; }
        [ForeignKey("AgareID")]
	    public virtual Agare agare { get; set; }
        [DisplayName("Fordonstyp Id")]
        public int FtypID { get; set; }
        [ForeignKey("FtypID")]
        public virtual Fordonstyp fordontyp { get; set; } // Virtual är enklaste sättet att fixa nån bugg
        [DisplayName("Parkeringsdatum")]
        public DateTime? Pdatum { get; set; } // ? Anger att datum kan vara null annars blir det fel vid generering
        [DisplayName("Plats Nr")]
        public int PplatsNr { get; set; }
        [DisplayName("Startdatum")]
        public DateTime? StartDatum { get; set; }
        [DisplayName("Slutdatum")]
        public DateTime? SlutDatum { get; set; }

    }
}