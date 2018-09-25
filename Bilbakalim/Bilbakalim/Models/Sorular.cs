using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Bilbakalim.Models
{
    [Table("Sorular")]
    public class Sorular
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoruId { get; set; }

        [StringLength(120)]
        public string Soru { get; set; }

        public virtual List<Cevaplar> Cevaplar { get; set; }
    }
}