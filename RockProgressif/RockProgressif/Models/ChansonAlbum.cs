using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RockProgressif.Models
{
    [Table("ChansonAlbum", Schema = "Albums")]
    public partial class ChansonAlbum
    {
        [Key]
        [Column("ChansonAlbumID")]
        public int ChansonAlbumId { get; set; }
        [Column("ChansonID")]
        public int ChansonId { get; set; }
        [Column("AlbumID")]
        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        [InverseProperty("ChansonAlbums")]
        public virtual Album Album { get; set; } = null!;
        [ForeignKey("ChansonId")]
        [InverseProperty("ChansonAlbums")]
        public virtual Chanson Chanson { get; set; } = null!;
    }
}
