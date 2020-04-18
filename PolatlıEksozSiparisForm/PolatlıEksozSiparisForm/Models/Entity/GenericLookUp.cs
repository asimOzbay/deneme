using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Entity
{
    public class GenericLookUp
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Aciklama { get; set; }
        public long GenericLookUpTypeID { get; set; }


        public ICollection<Urun> UrunKategori { get; set; }

        public ICollection<Urun> UrunTipi { get; set; }
        


        [ForeignKey("GenericLookUpTypeID")]
        public GenericLookUpType GenericLookUpType { get; set; }
    }
}