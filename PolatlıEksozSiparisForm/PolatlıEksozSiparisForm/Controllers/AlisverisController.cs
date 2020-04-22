using PolatlıEksozSiparisForm.Models.Cache;
using PolatlıEksozSiparisForm.Models.Context;
using PolatlıEksozSiparisForm.Models.Entity;
using PolatlıEksozSiparisForm.Models.VMs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Controllers
{
    public class AlisverisController : BaseController
    {
        // GET: Admin
        public ActionResult Index(string text)
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2 && x.Aktif == true);

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


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1 && x.Aktif == true);

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
            var urunListesi = db.Urun.Where(x => x.Aktif == true).ToList();
            if (urunListesi != null && !string.IsNullOrEmpty(text))
            {
                urunListesi = urunListesi.Where(x => x.Adi.Contains(text)).ToList();
            }
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





        public ActionResult UrunDetay()
        {
            return View();
        }






        [YeniAuthorize]
        public ActionResult UrunEkle()
        {
            ContextDB db = new ContextDB();

            //kategori listesini veri tabanından çektik
            var kategoriListesiDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 2 && x.Aktif == true);

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


            var tipListDB = db.GenericLookUp.Where(x => x.GenericLookUpTypeID == 1 && x.Aktif == true);

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
            var urunListesi = db.Urun.Where(x => x.Aktif == true).ToList();
            foreach(var item in urunListesi)
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

        [HttpPost]
        public ActionResult UrunPost(UrunVM vm, HttpPostedFileBase file)
        {
            string fileName = GetFileName() + ".jpg";
            if (file != null)
            {
                
                string filePath = Path.Combine(Server.MapPath("~/UrunFotolari/"), fileName);  //Path.GetFullPath(@"C:/Content/Images/" + fileName); bu kullanım şöyle de Kullanılabilir "C:\\Content\\Images\\" + fileName;
                file.SaveAs(filePath);
            }
            Urun urun = new Urun { Adi = vm.Adi, Fiyati = vm.Fiyati, StokMiktari = vm.StokMiktari, UrunTipiLookUpID = vm.UrunTipiLookUpID, KategoriLookUpID = vm.KategoriLookUpID, UserID = vm.UserID };
            urun.UserID = 2;

            ContextDB db = new ContextDB();
            var dbUrun = db.Urun.FirstOrDefault(x => x.Adi == vm.Adi && x.Aktif == true);


            if (dbUrun == null)
            {
                db.Urun.Add(urun);

                db.SaveChanges();

                UrunFoto urunFoto = new UrunFoto { UrunID = urun.ID, DosyaAdi = fileName, Path = "/UrunFotolari/" + fileName };
                db.UrunFoto.Add(urunFoto);
                db.SaveChanges();


               

                TempData["Message"] = "Kayıt Başarılı";
                TempData["Success"] = true;
                return RedirectToAction("Index");
            }
            else if (dbUrun.StokMiktari != vm.StokMiktari)
            {
                db.Urun.Remove(dbUrun);
                db.Urun.Add(urun);
                db.SaveChanges();
            }
            else

                TempData["Message"] = "Kayıt Mevcut";
            TempData["Success"] = false;
            return RedirectToAction("UrunEkle");

        }


        public string GetFileName()
        {
            var yil = DateTime.Now;
            var month = yil.Month < 10 ? "0" + yil.Month.ToString() : yil.Month.ToString();
            var day = yil.Day < 10 ? "0" + yil.Day.ToString() : yil.Day.ToString();
            var hour = yil.Hour < 10 ? "0" + yil.Hour.ToString() : yil.Hour.ToString();
            var minute = yil.Minute < 10 ? "0" + yil.Minute.ToString() : yil.Minute.ToString();
            var second = yil.Second < 10 ? "0" + yil.Second.ToString() : yil.Second.ToString();

            return yil.Year + month + day + hour + minute + second;
        }

        public JsonResult UrunSil(long id)
        {
            try
            {
                ContextDB db = new ContextDB();
                var urun = db.Urun.FirstOrDefault(x => x.ID == id && x.Aktif == true);
                if(urun != null)
                {
                    urun.Aktif = false;
                    db.SaveChanges();

                    var urunFoto = db.UrunFoto.FirstOrDefault(x => x.UrunID == urun.ID && x.Aktif);
                    if (urunFoto != null)
                    {
                        urunFoto.Aktif = false;
                        db.SaveChanges();
                    }
                    return Json(new { success = "basarili", mesaj = "Başarıyla silindi." });
                }
                return Json(new { success = "basarisiz", mesaj = "İşlem sırasında bir hata ile karşılaşıldı" });
            }
            catch (Exception ex)
            {
                return Json(new {success = "basarisiz", mesaj = "İşlem sırasında bir hata ile karşılaşıldı" });
            }
        }
    }
}

