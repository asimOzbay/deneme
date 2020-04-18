using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.VMs
{
    public class userVM
    {
        [Required(ErrorMessage = "Adı alanı boş geçilemez!")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Soyadı alanı boş geçilemez!")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "E-Mail alanı boş geçilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Sifre alanı boş geçilemez!")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Sifre Tekrarı alanı boş geçilemez!")]
        public string SifreTekrari { get; set; }


        public long selected { get; set; }
    }
}