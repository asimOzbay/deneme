using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Entity
{
    public class Users
    {
        public long ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string KullaniciAdi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}