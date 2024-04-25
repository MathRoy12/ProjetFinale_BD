using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Keyless]
    public partial class VwLiensArtisteGroupe
    {
        [Column("ArtisteID")]
        public int ArtisteId { get; set; }
        [StringLength(50)]
        public string? NomScene { get; set; }
        [StringLength(100)]
        public string NomArtiste { get; set; } = null!;
        [Column("GroupeID")]
        public int GroupeId { get; set; }
        [StringLength(100)]
        public string NomGroupe { get; set; } = null!;
        [StringLength(50)]
        public string Instrument { get; set; } = null!;
    }
}
