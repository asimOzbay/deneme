using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Entity
{
    public class UrunSiparis
    {
        public UrunSiparis()
        {
            Aktif = true;
        }
        public long ID { get; set; }
        public long UrunID { get; set; }
        public long SiparisID { get; set; }
        public int SiparisEdilenUrunAdedi { get; set; }
        public bool Aktif { get; set; }


        [ForeignKey("SiparisID")]
        public Siparis Siparis { get; set; }

        [ForeignKey("UrunID")]
        public Urun Urun { get; set; }
    }


}