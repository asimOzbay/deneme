using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Entity
{
    public class UrunFoto
    {
        public long ID { get; set; }
        public long UrunID { get; set; }
        public string DosyaAdi { get; set; }
        public string Path { get; set; }

        [ForeignKey("UrunID")]
        public Urun Urun { get; set; }
    }
}