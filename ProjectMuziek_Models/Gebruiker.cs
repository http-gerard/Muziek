using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMuziek_Models
{
    class Gebruiker
    {
        public int GebruikerId { get; set; }
        public string Voornaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }

        [DefaultValue("false")]
        public bool IsLid { get; set; }
        [DefaultValue("false")]
        public bool IsAdmin { get; set; }
        [DefaultValue("false")]
        public bool IsSuperAdmin { get; set; }

        public ICollection<BeluisterdLied> beluisterdLieds { get; set; }

        public Gebruiker()
        {

        }

        public Gebruiker(string voornaam, string email, string wachtwoord)
        {
           
            Email = email;
            Voornaam = voornaam;
            
            Wachtwoord = wachtwoord;
            
        }
    }
}
