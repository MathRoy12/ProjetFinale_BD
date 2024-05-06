using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Table("Album", Schema = "Albums")]
    [Index("IdentifiantCover", Name = "UC_Album_IdentifiantCover", IsUnique = true)]
    public partial class Album
    {
        public Album()
        {
            ChansonAlbums = new HashSet<ChansonAlbum>();
        }

        [Key]
        [Column("AlbumID")]
        public int AlbumId { get; set; }
        [StringLength(865)]
        public string Nom { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DatePublication { get; set; }
        public int NombreVentes { get; set; }
        public int NoteCritiques { get; set; }
        [Column("GroupeID")]
        public int GroupeId { get; set; }
        public Guid IdentifiantCover { get; set; }
        public byte[]? CoverContent { get; set; }

        [ForeignKey("GroupeId")]
        [InverseProperty("Albums")]
        public virtual Groupe Groupe { get; set; } = null!;
        [InverseProperty("Album")]
        public virtual ICollection<ChansonAlbum> ChansonAlbums { get; set; }
    }
}
