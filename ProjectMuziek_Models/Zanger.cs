using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMuziek_Models
{
    class Zanger
    {
        [Key]
        public int ZangerId { get; set; }
        public string VolledigeNaam { get; set; }

        public Zanger()
        {

        }
        public Zanger(string volledigeNaam)
        {
            VolledigeNaam = volledigeNaam;
        }
    }
}
