using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bilbakalim.Models
{
    [Table("Cevaplar")]
    public class Cevaplar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CevapId { get; set; }

        [StringLength(30)]
        public string Cevap { get; set; }

        public virtual Sorular Soru { get; set; }
    }
}