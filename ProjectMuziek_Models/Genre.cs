using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMuziek_Models
{
    class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string naam { get; set; }
    }
}

