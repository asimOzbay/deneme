using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.VMs
{
    public class UrunVM
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Adi Alanı Boş geçilemez.")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Fiyat Alanı Boş geçilemez.")]
        public decimal Fiyati { get; set; }
        [Required(ErrorMessage = "StokMiktarı Alanı Boş geçilemez.")]
        public int StokMiktari { get; set; }

        public int SepettekiUrunAdedi { get; set; }
        public long UserID { get; set; }

        public long KategoriLookUpID { get; set; }

        public string KategoriAdi { get; set; }

        public long UrunTipiLookUpID { get; set; }

        public string UrunTipiAdi { get; set; }
    }
}