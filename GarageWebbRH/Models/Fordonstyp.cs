using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageWebbRH.Models
{
    public class Fordonstyp
    {
        [Key]
        public int FtypId { get; set; }
        public string Namn { get; set; }
        public double TimPris { get; set; }
    }
}