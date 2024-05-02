using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Keyless]
    [Table("GroupeEnClair", Schema = "Groupes")]
    public partial class GroupeEnClair
    {
        public int GroupeId { get; set; }
        [StringLength(100)]
        public string Nom { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateFormation { get; set; }
        public int TotaleAlbumVendue { get; set; }
    }
}
