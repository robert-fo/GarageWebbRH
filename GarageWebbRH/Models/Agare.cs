using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageWebbRH.Models
{
    public class Agare
    {
        [Key]
        public int AgareId { get; set; }
        [DisplayName("Förnamn")]
        public string Fnamn { get; set; }
        [DisplayName("Efternamn")]
        public string Enamn { get; set; }
        public string TelefonNr { get; set; }
    }
}