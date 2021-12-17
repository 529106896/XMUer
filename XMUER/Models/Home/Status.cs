using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XMUER.Models.Home
{
    [Table("status")]
    public class Status
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("user_id")]
        public int UserID { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("state")]
        public int State { get; set; }

        [Column("like")]
        public int Like { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }
    }
}
