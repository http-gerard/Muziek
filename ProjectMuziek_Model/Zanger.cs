using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMuziek_Model
{
    public class Zanger
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
