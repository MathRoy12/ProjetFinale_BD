using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Table("Artiste", Schema = "Groupes")]
    public partial class Artiste
    {
        public Artiste()
        {
            Roles = new HashSet<Role>();
        }

        [Key]
        [Column("ArtisteID")]
        public int ArtisteId { get; set; }
        [StringLength(50)]
        public string? NomScene { get; set; }
        [StringLength(100)]
        public string NomComplet { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateNaissance { get; set; }

        [InverseProperty("Artiste")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
