using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Table("Role", Schema = "Groupes")]
    public partial class Role
    {
        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(50)]
        public string Instrument { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateDebut { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateFin { get; set; }
        public bool EstMembreOfficiel { get; set; }
        [Column("GroupeID")]
        public int GroupeId { get; set; }
        [Column("ArtisteID")]
        public int ArtisteId { get; set; }

        [ForeignKey("ArtisteId")]
        [InverseProperty("Roles")]
        public virtual Artiste Artiste { get; set; } = null!;
        [ForeignKey("GroupeId")]
        [InverseProperty("Roles")]
        public virtual Groupe Groupe { get; set; } = null!;
    }
}
