using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Entity
{
    public class Urun
    {
        public long ID { get; set; }
        public string Adi { get; set; }
        public decimal Fiyati { get; set; }
        public int StokMiktari { get; set; }
        public long UserID{ get; set; }
        public long KategoriLookUpID { get; set; }
        public long UrunTipiLookUpID { get; set; }


        [ForeignKey("UserID")]
        public Users Users { get; set; }

        [ForeignKey("KategoriLookUpID")]
        public GenericLookUp GenericLookUp_Kategori { get; set; }

        [ForeignKey("UrunTipiLookUpID")]
        public GenericLookUp GenericLookUp_UrunTipi { get; set; }

        public ICollection<UrunFoto> UrunFoto { get; set; }
    }
}