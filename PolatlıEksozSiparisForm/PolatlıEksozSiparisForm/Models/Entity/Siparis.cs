using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Entity
{
    public class Siparis
    {
        public Siparis()
        {
            Aktif = true;
        }
        public long ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string ÜlkeAdi { get; set; }
        public string PostaKodu { get; set; }
        public string Adres { get; set; }
        public string IlceIl { get; set; }
        public string TelefonNo { get; set; }
        public long UserID { get; set; }
        public bool Aktif { get; set; }

        public ICollection<UrunSiparis> UrunSiparis { get; set; }
        

    }
}