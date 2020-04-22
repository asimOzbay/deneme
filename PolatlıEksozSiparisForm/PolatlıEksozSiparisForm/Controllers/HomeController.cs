using PolatlıEksozSiparisForm.Models.Context;
using PolatlıEksozSiparisForm.Models.Entity;
using PolatlıEksozSiparisForm.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
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

            var urunListesi = db.Urun.Where(x => x.Aktif).ToList();
            if (urunListesi != null)
            {
                foreach (var item in urunListesi)
                {
                    var urunFoto = db.UrunFoto.FirstOrDefault(x => x.UrunID == item.ID && x.Aktif);
                    string path = urunFoto != null ? urunFoto.Path : "/Content/img/products/man-2.jpg";
                    vm = new UrunVM();
                    vm.Path = path;
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

        public JsonResult Arama(string text)
        {
            ContextDB db = new ContextDB();
            var data = db.Urun.Where(x => x.Adi.Contains(text) && x.Aktif).ToList();
            List<AutoCompleteVM> liste = new List<AutoCompleteVM>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    AutoCompleteVM vm = new AutoCompleteVM();
                    vm.Adi = item.Adi;
                    vm.ID = item.ID;
                    liste.Add(vm);
                }
            }
            return Json(liste, JsonRequestBehavior.AllowGet);
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
            var urunListesi = db.Urun.Where(x => x.GenericLookUp_Kategori.Name == "Egzoz Aparatları" && x.Aktif).ToList();
            if (urunListesi != null)
            {
                foreach (var item in urunListesi)
                {
                    vm = new UrunVM();
                    vm.Adi = item.Adi;
                    vm.KategoriAdi = item.GenericLookUp_Kategori.Name;
                    vm.UrunTipiAdi = item.GenericLookUp_UrunTipi.Name;
                    vm.StokMiktari = item.StokMiktari;
                    vm.Fiyati = item.Fiyati;
                    urunlerListesi.Add(vm);
                }
            }
            return View(urunlerListesi);
        }
        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult GetSepetIcerigi()
        {
            var sepettekiUrunler = new List<SepetVM>();
            sepettekiUrunler = (List<SepetVM>)Session["SepettekiUrunler"];
            return Json(sepettekiUrunler, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SepetPartial()
        {
            return View();
        }


        public JsonResult SepeteEkle(long ID)
        {
            try
            {
                var liste = new List<SepetVM>();
                ContextDB db = new ContextDB();
                var urun = db.Urun.FirstOrDefault(x => x.ID == ID && x.Aktif);

                var urunFoto = db.UrunFoto.FirstOrDefault(x => x.UrunID == urun.ID && x.Aktif);
                string path = urunFoto != null ? urunFoto.Path : "/Content/img/products/man-2.jpg";
                var eklenecekUrunVM = new SepetVM { ID = urun.ID, Adi = urun.Adi, Fiyati = urun.Fiyati, SepettekiUrunAdedi = 1, Path = path };

                if (Session["SepettekiUrunler"] != null && Session["SepetUrunAdedi"] != null)
                {
                    liste = (List<SepetVM>)Session["SepettekiUrunler"];
                    if (liste != null && liste.Any(x => x.ID == ID))
                    {
                        var cikarilacak = liste.FirstOrDefault(x => x.ID == ID);
                        liste.Remove(cikarilacak);
                        cikarilacak.SepettekiUrunAdedi += 1;
                        liste.Add(cikarilacak);
                    }
                    else
                    {
                        liste.Add(eklenecekUrunVM);
                    }
                }
                else
                {
                    liste.Add(eklenecekUrunVM);
                }
                Session["SepettekiUrunler"] = liste;
                Session["SepetUrunAdedi"] = liste.Count();
                return Json(new { sonuc = "basarili", message = "ürün sepete eklendi", urunAdedi = liste.Count()});
            }
            catch (Exception ex)
            {
                return Json(new { sonuc = "basarisiz", message = "ürün eklenirken bir hata ile karşılaşıldı." });
            }
        }

    }
}