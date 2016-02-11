using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageWebbRH.Models
{
    public class Fordon
    {
        [Key]
        public string regNr { get; set; }
        public enum fordonsTyp { Bil, MC, Buss, Lastbil }
        public string agare { get; set; }
        public DateTime pDatum { get; set; }
        public DateTime startDatum { get; set; }
        public DateTime slutDatum { get; set; }
    }
}