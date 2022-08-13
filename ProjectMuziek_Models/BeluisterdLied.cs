using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMuziek_Models
{
    class BeluisterdLied
    {
        [Key]
        public int BeluisterdLiedId { get; set; }
        public DateTime Datum { get; set; }
        [DefaultValue(0.00)]
        public int GebruikerId { get; set; }
        [ForeignKey("GebruikerId")]
        public Gebruiker Gebruiker { get; set; }
        public int LiedId { get; set; }
        [ForeignKey("LiedId")]
        public Lied Lied { get; set; }


        public BeluisterdLied(DateTime datum, int gebuikerId, int liedId)
        {
            Datum = datum;
            GebruikerId = gebuikerId;
            LiedId = liedId;
        }

        public BeluisterdLied()
        {

        }
    }
}
