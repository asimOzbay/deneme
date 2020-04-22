using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.VMs
{
    public class SepetVM
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Adi Alanı Boş geçilemez.")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Fiyat Alanı Boş geçilemez.")]
        public decimal Fiyati { get; set; }
        public int SepettekiUrunAdedi { get; set; }

        public string Path { get; set; }
    }
}