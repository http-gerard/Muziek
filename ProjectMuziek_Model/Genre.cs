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
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string naam { get; set; }
    }
}
