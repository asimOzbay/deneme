using PolatlıEksozSiparisForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("name=ConString")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<GenericLookUp> GenericLookUp { get; set; }
        public DbSet<GenericLookUpType> GenericLookUpType { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<UrunFoto> UrunFoto { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<UrunSiparis> UrunSiparis { get; set; }

    }
}