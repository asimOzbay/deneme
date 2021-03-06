﻿using PolatlıEksozSiparisForm.Models.Context;
using PolatlıEksozSiparisForm.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Controllers
{
    public class KategoriController : BaseController
    {
        // GET: Kategoriler
        public ActionResult Egzoz()
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2 && x.Aktif);

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


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1 && x.Aktif);

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
            var urunListesi = db.Urun.Where(x => x.Aktif == true && x.GenericLookUp_Kategori.Name == "Egzoz").ToList();
            foreach (var item in urunListesi)
            {
                var urunFoto = db.UrunFoto.FirstOrDefault(x => x.UrunID == item.ID && x.Aktif == true);
                string path = urunFoto != null ? urunFoto.Path : "/Content/img/products/man-2.jpg";
                vm = new UrunVM();
                vm.Path = path;
                vm.ID = item.ID;
                vm.Adi = item.Adi;
                vm.KategoriAdi = item.GenericLookUp_Kategori.Name;
                vm.UrunTipiAdi = item.GenericLookUp_UrunTipi.Name;
                vm.StokMiktari = item.StokMiktari;
                vm.Fiyati = item.Fiyati;
                urunlerListesi.Add(vm);

            }
            return View(urunlerListesi);
            

        }

        public ActionResult Katalizor()
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2 && x.Aktif);

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


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1 && x.Aktif);

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
            var urunListesi = db.Urun.Where(x => x.Aktif == true && x.GenericLookUp_Kategori.Name == "Katalizör").ToList();
            foreach (var item in urunListesi)
            {
                var urunFoto = db.UrunFoto.FirstOrDefault(x => x.UrunID == item.ID && x.Aktif == true);
                string path = urunFoto != null ? urunFoto.Path : "/Content/img/products/man-2.jpg";
                vm = new UrunVM();
                vm.Path = path;
                vm.ID = item.ID;
                vm.Adi = item.Adi;
                vm.KategoriAdi = item.GenericLookUp_Kategori.Name;
                vm.UrunTipiAdi = item.GenericLookUp_UrunTipi.Name;
                vm.StokMiktari = item.StokMiktari;
                vm.Fiyati = item.Fiyati;
                urunlerListesi.Add(vm);

            }
            return View(urunlerListesi);
           

        }
         public ActionResult EgzozAparatları()
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2 && x.Aktif);

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


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1 && x.Aktif);

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
            var urunListesi = db.Urun.Where(x => x.Aktif == true && x.GenericLookUp_Kategori.Name == "Egzoz Aparatları").ToList();
            
            foreach (var item in urunListesi)
            {
                var urunFoto = db.UrunFoto.FirstOrDefault(x => x.UrunID == item.ID && x.Aktif == true);
                string path = urunFoto != null ? urunFoto.Path : "/Content/img/products/man-2.jpg";
                vm = new UrunVM();
                vm.Path = path;
                vm.ID = item.ID;
                vm.Adi = item.Adi;
                vm.KategoriAdi = item.GenericLookUp_Kategori.Name;
                vm.UrunTipiAdi = item.GenericLookUp_UrunTipi.Name;
                vm.StokMiktari = item.StokMiktari;
                vm.Fiyati = item.Fiyati;
                urunlerListesi.Add(vm);

            }
            return View(urunlerListesi);
            

        }

      
    }
}