using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Table("Groupe", Schema = "Groupes")]
    public partial class Groupe
    {
        public Groupe()
        {
            Albums = new HashSet<Album>();
            Roles = new HashSet<Role>();
        }

        [Key]
        [Column("GroupeID")]
        public int GroupeId { get; set; }
        [StringLength(100)]
        public string Nom { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateFormation { get; set; }
        public byte[]? TotaleAlbumVendue { get; set; }

        [InverseProperty("Groupe")]
        public virtual ICollection<Album> Albums { get; set; }
        [InverseProperty("Groupe")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
