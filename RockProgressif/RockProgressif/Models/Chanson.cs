using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Table("Chanson", Schema = "Albums")]
    public partial class Chanson
    {
        public Chanson()
        {
            ChansonAlbums = new HashSet<ChansonAlbum>();
        }

        [Key]
        [Column("ChansonID")]
        public int ChansonId { get; set; }
        [StringLength(210)]
        public string Titre { get; set; } = null!;
        public int DureeSeconde { get; set; }

        [InverseProperty("Chanson")]
        public virtual ICollection<ChansonAlbum> ChansonAlbums { get; set; }
    }
}
