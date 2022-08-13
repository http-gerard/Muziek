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
    public class Lied
    {
        [Key]
        public int LiedId { get; set; }
        public string Titel { get; set; }
        public string Producer { get; set; }
        public string PlatenLabel { get; set; }
        public string UitgaveJaar { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int ZangerId { get; set; }
        [ForeignKey("ZangerId")]
        public Zanger Zanger { get; set; }

        public bool IsBeluisterd { get; set; }
        [DefaultValue("false")]
        public ICollection<BeluisterdLied> BeluisterdLieds { get; set; }
        public Lied()
        {

        }
        public Lied(string titel, string uitgaveJaar, int genreId, int zangerId, string platenLabel, string producer)
        {
            Titel = titel;
            PlatenLabel = platenLabel;
            UitgaveJaar = uitgaveJaar;
            Producer = producer;

            GenreId = genreId;

            ZangerId = zangerId;
        }
    }
}
