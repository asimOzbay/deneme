using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Entity
{
    public class GenericLookUpType
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Aciklama { get; set; }


        public ICollection<GenericLookUp> GenericLookUp { get; set; }
    }
}