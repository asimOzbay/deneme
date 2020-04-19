using PolatlıEksozSiparisForm.Models.Context;
using PolatlıEksozSiparisForm.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategoriler
        public ActionResult Egzoz()
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2);

            //combobox SelectListItem listesiyle kullanıldığı için yeni bir liste oluşturduk.
            List<SelectListItem> kategoriListesi = new List<SelectListItem>();

            //SelectListItem listesine veri tabanından gelen listenin Adı ve ID leri atılıyor ve listeye ekleniyor
            foreach (var item in kategoriListesiDB)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ID.ToString();
                kategoriListesi.Add(selectListItem);
            }


            //db den gelen liste SelectListItem listesine atıldıktan sonra son hali tempdata ile cshtml e atılıyor. (Login/Index sayfasında kullanıldı)
            TempData["kategoriListesi"] = kategoriListesi;


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1);

            //combobox SelectListItem listesiyle kullanıldığı için yeni bir liste oluşturduk.
            List<SelectListItem> tipListesi = new List<SelectListItem>();

            //SelectListItem listesine veri tabanından gelen listenin Adı ve ID leri atılıyor ve listeye ekleniyor
            foreach (var item in tipListDB)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ID.ToString();
                tipListesi.Add(selectListItem);
            }


            //db den gelen liste SelectListItem listesine atıldıktan sonra son hali tempdata ile cshtml e atılıyor. (Login/Index sayfasında kullanıldı)
            TempData["tipListesi"] = tipListesi;

            List<UrunVM> urunlerListesi = new List<UrunVM>();
            UrunVM vm;
            var urunListesi = db.Urun.Where(x => x.GenericLookUp_Kategori.Name == "Egzoz").ToList();
            if (urunListesi != null)
            {
                foreach (var item in urunListesi)
                {
                    vm = new UrunVM();
                    vm.Adi = item.Adi;
                    vm.ID = item.ID;
                    vm.KategoriAdi = item.GenericLookUp_Kategori.Name;
                    vm.UrunTipiAdi = item.GenericLookUp_UrunTipi.Name;
                    vm.StokMiktari = item.StokMiktari;
                    vm.Fiyati = item.Fiyati;
                    urunlerListesi.Add(vm);
                }
            }
            return View(urunlerListesi);

        }

        public ActionResult Katalizor()
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2);

            //combobox SelectListItem listesiyle kullanıldığı için yeni bir liste oluşturduk.
            List<SelectListItem> kategoriListesi = new List<SelectListItem>();

            //SelectListItem listesine veri tabanından gelen listenin Adı ve ID leri atılıyor ve listeye ekleniyor
            foreach (var item in kategoriListesiDB)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ID.ToString();
                kategoriListesi.Add(selectListItem);
            }


            //db den gelen liste SelectListItem listesine atıldıktan sonra son hali tempdata ile cshtml e atılıyor. (Login/Index sayfasında kullanıldı)
            TempData["kategoriListesi"] = kategoriListesi;


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1);

            //combobox SelectListItem listesiyle kullanıldığı için yeni bir liste oluşturduk.
            List<SelectListItem> tipListesi = new List<SelectListItem>();

            //SelectListItem listesine veri tabanından gelen listenin Adı ve ID leri atılıyor ve listeye ekleniyor
            foreach (var item in tipListDB)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ID.ToString();
                tipListesi.Add(selectListItem);
            }


            //db den gelen liste SelectListItem listesine atıldıktan sonra son hali tempdata ile cshtml e atılıyor. (Login/Index sayfasında kullanıldı)
            TempData["tipListesi"] = tipListesi;

            List<UrunVM> urunlerListesi = new List<UrunVM>();
            UrunVM vm;
            var urunListesi = db.Urun.Where(x => x.GenericLookUp_Kategori.Name == "Katalizör").ToList();
            if (urunListesi != null)
            {
                foreach (var item in urunListesi)
                {
                    vm = new UrunVM();
                    vm.Adi = item.Adi;
                    vm.ID = item.ID;
                    vm.KategoriAdi = item.GenericLookUp_Kategori.Name;
                    vm.UrunTipiAdi = item.GenericLookUp_UrunTipi.Name;
                    vm.StokMiktari = item.StokMiktari;
                    vm.Fiyati = item.Fiyati;
                    urunlerListesi.Add(vm);
                }
            }
            return View(urunlerListesi);

        }
         public ActionResult EgzozAparatları()
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2);

            //combobox SelectListItem listesiyle kullanıldığı için yeni bir liste oluşturduk.
            List<SelectListItem> kategoriListesi = new List<SelectListItem>();

            //SelectListItem listesine veri tabanından gelen listenin Adı ve ID leri atılıyor ve listeye ekleniyor
            foreach (var item in kategoriListesiDB)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ID.ToString();
                kategoriListesi.Add(selectListItem);
            }


            //db den gelen liste SelectListItem listesine atıldıktan sonra son hali tempdata ile cshtml e atılıyor. (Login/Index sayfasında kullanıldı)
            TempData["kategoriListesi"] = kategoriListesi;


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1);

            //combobox SelectListItem listesiyle kullanıldığı için yeni bir liste oluşturduk.
            List<SelectListItem> tipListesi = new List<SelectListItem>();

            //SelectListItem listesine veri tabanından gelen listenin Adı ve ID leri atılıyor ve listeye ekleniyor
            foreach (var item in tipListDB)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ID.ToString();
                tipListesi.Add(selectListItem);
            }


            //db den gelen liste SelectListItem listesine atıldıktan sonra son hali tempdata ile cshtml e atılıyor. (Login/Index sayfasında kullanıldı)
            TempData["tipListesi"] = tipListesi;

            List<UrunVM> urunlerListesi = new List<UrunVM>();
            UrunVM vm;
            var urunListesi = db.Urun.Where(x => x.GenericLookUp_Kategori.Name == "Egzoz Aparatları").ToList();
            if (urunListesi != null)
            {
                foreach (var item in urunListesi)
                {
                    vm = new UrunVM();
                    vm.Adi = item.Adi;
                    vm.ID = item.ID;
                    vm.KategoriAdi = item.GenericLookUp_Kategori.Name;
                    vm.UrunTipiAdi = item.GenericLookUp_UrunTipi.Name;
                    vm.StokMiktari = item.StokMiktari;
                    vm.Fiyati = item.Fiyati;
                    urunlerListesi.Add(vm);
                }
            }
            return View(urunlerListesi);

        }

      
    }
}