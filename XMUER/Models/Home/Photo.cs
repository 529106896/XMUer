using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XMUER.Models.Home
{
    [Table("photo")]
    public class Photo
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("album_id")]
        public int AlbumID { get; set; }

        [Column("picture")]
        public string Picture { get; set; }
    }
}
