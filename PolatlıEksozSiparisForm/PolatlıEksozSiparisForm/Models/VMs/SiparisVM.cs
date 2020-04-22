using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.VMs
{
    public class SiparisVM
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Adi Alanı Boş geçilemez.")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Soyadi Alanı Boş geçilemez.")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "E-mail Alanı Boş geçilemez.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şirket Alanı Boş geçilemez.")]
        public string Şirket { get; set; }
        [Required(ErrorMessage = "Ülke Adı Alanı Boş geçilemez.")]
        public string ÜlkeAdi { get; set; }
        [Required(ErrorMessage = "Posta kodu Alanı Boş geçilemez.")]
        public string PostaKodu { get; set; }
        [Required(ErrorMessage = "Adres Alanı Boş geçilemez.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "İl / İlçe Alanı Boş geçilemez.")]
        public string IlceIl { get; set; }
        [Required(ErrorMessage = "Telefon numarası Alanı Boş geçilemez.")]
        public string TelefonNo { get; set; }


        public int ToplamUrunAdedi { get; set; }
        public decimal ToplamTutar { get; set; }

    }
}