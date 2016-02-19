using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageWebbRH.Models
{
    public class Agare
    {
        [Key]
        public int AgareId { get; set; }
        public string Fnamn { get; set; }
        public string Enamn { get; set; }
        public string TelefonNr { get; set; }
    }
}