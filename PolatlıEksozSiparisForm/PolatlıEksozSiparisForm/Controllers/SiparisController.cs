using PolatlıEksozSiparisForm.Models.Cache;
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
    public class SiparisController : BaseController
    {
        // GET: Siparis
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Alisveris()
        {
            return View();
        }

        [YeniAuthorize]
        public ActionResult Odeme()
        {

            return View();
        }


        [YeniAuthorize]
        public ActionResult Siparisler()
        {
            List<SiparisVM> siparisListesi = new List<SiparisVM>();
            ContextDB db = new ContextDB();

            var kullanici = SesionHelper.Get<Users>("Kullanici");
            List<Siparis> siparisDBList = new List<Siparis>();

            if(kullanici != null && kullanici.Email == "asmzby@gmail.com")
            {
                siparisDBList = db.Siparis.Where(x => x.Aktif).ToList();
            }
            else
            {
                siparisDBList = db.Siparis.Where(x => x.UserID == kullanici.ID && x.Aktif).ToList();
            }
            //var dbsdsad = db.Siparis.ToList();
            foreach(var item in siparisDBList)
            {
                SiparisVM vm = new SiparisVM();
                vm.ID = item.ID;
                vm.IlceIl = item.IlceIl;
                vm.Adres = item.Adres;
                vm.Adi = item.Adi;
                vm.Soyadi = item.Soyadi;
                int toplamUrunAdedi = 0;
                vm.Email = item.Email;
                decimal toplamUrunFiyati = 0;
                var urunSiparisler = db.UrunSiparis.Where(x => x.SiparisID == item.ID && x.Aktif).OrderByDescending(x => x.ID).ToList();
                foreach (var urunSiparis in urunSiparisler)
                {
                    decimal urunFiyat = 0;
                    var urunResult = db.Urun.FirstOrDefault(x => x.ID == urunSiparis.UrunID);
                    if (urunResult != null)
                        urunFiyat = urunResult.Fiyati;
                    toplamUrunAdedi = toplamUrunAdedi + urunSiparis.SiparisEdilenUrunAdedi;
                    toplamUrunFiyati = toplamUrunFiyati + (urunFiyat * urunSiparis.SiparisEdilenUrunAdedi);
                }
                vm.ToplamUrunAdedi = toplamUrunAdedi;
                vm.ToplamTutar = toplamUrunFiyati;

                siparisListesi.Add(vm);
            }
            if (siparisListesi != null && siparisListesi.Count > 0)
                siparisListesi = siparisListesi.OrderByDescending(x => x.ID).ToList();

            return View(siparisListesi);
        }

        [HttpPost]
        public ActionResult SiparisKayit(SiparisVM vm)
        {
            try
            {
                var user = SesionHelper.Get<Users>("Kullanici");
                long userID = 0;
                if (user != null && user.ID != 0)
                {
                    userID = user.ID;
                }
                ContextDB db = new ContextDB();
                Siparis siparis = new Siparis { Adi = vm.Adi, Email = vm.Email, Adres = vm.Adres, IlceIl = vm.IlceIl, PostaKodu = vm.PostaKodu, Soyadi = vm.Soyadi, TelefonNo = vm.TelefonNo, ÜlkeAdi = vm.ÜlkeAdi, UserID = userID };
                db.Siparis.Add(siparis);
                db.SaveChanges();

                var sepettekiUrunler = new List<SepetVM>();
                List<long> rerer = new List<long>();
                sepettekiUrunler = (List<SepetVM>)Session["SepettekiUrunler"];

                List<UrunSiparis> urunSiparis = new List<UrunSiparis>();
                List<Urun> dbUrunler = new List<Urun>();//stoktan düşürülecekleri tutacağımız liste

                if (sepettekiUrunler != null && sepettekiUrunler.Count > 0)
                {
                    rerer = sepettekiUrunler.Select(x => x.ID).ToList();
                    dbUrunler = db.Urun.Where(x => rerer.Contains(x.ID) && x.Aktif).ToList();
                    foreach(var item in dbUrunler)
                    {
                        item.StokMiktari = item.StokMiktari - sepettekiUrunler.FirstOrDefault(x => x.ID == item.ID).SepettekiUrunAdedi;

                    }
                    db.SaveChanges();
                }
                foreach (var item in sepettekiUrunler)
                {
                    UrunSiparis urun = new UrunSiparis();
                    urun.SiparisID = siparis.ID;
                    urun.UrunID = item.ID;
                    urun.SiparisEdilenUrunAdedi = item.SepettekiUrunAdedi;
                    urunSiparis.Add(urun);


                }

                if (urunSiparis.Count > 0)
                {
                    db.UrunSiparis.AddRange(urunSiparis);
                    db.SaveChanges();
                }

                if(dbUrunler != null && dbUrunler.Count > 0)
                {
                    foreach(var item in dbUrunler)
                    {
                        var result = db.Urun.FirstOrDefault(x => x.ID == item.ID && x.Aktif);
                        if (result != null)
                        {
                            result.StokMiktari = item.StokMiktari;
                            db.SaveChanges();
                        }
                    }
                }


                return RedirectToAction("Siparisler");

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult SiparisDetay(long? id)
        {
            List<SepetVM> urunList = new List<SepetVM>();
            if(id != null && id != 0)
            {
                ContextDB db = new ContextDB();
                var siparis = db.Siparis.FirstOrDefault(x => x.ID == id.Value && x.Aktif);
                if(siparis != null)
                {
                    var urunSiparis = db.UrunSiparis.Where(x => x.SiparisID == siparis.ID && x.Aktif);
                    if (urunSiparis != null)
                    {
                        var urunIDler = urunSiparis.Select(y => y.UrunID);
                        var urunler = db.Urun.Where(x => urunIDler.Contains(x.ID)).ToList();
                        foreach (var item in urunler)
                        {
                            var urunFoto = db.UrunFoto.FirstOrDefault(x => x.UrunID == item.ID && x.Aktif);
                            string path = urunFoto != null ? urunFoto.Path : "/Content/img/katalizor/katalizor-2.jpg";
                            SepetVM sepetVM = new SepetVM { Adi = item.Adi, Fiyati = item.Fiyati, SepettekiUrunAdedi = urunSiparis.FirstOrDefault(x => x.UrunID == item.ID).SiparisEdilenUrunAdedi, Path = path };
                            urunList.Add(sepetVM);
                        }
                    }
                }
            }
            return View(urunList);
        }

        public JsonResult SepetUrunSil(long id)
        {
            decimal toplam = 0;
            try
            {
                List<SepetVM> sepettekiUrunler = new List<SepetVM>();
                sepettekiUrunler = (List<SepetVM>)Session["SepettekiUrunler"];
                if (sepettekiUrunler != null)
                {
                    var urun = sepettekiUrunler.FirstOrDefault(x => x.ID == id);
                    if (urun != null)
                    {
                        sepettekiUrunler.Remove(urun);
                        Session["SepettekiUrunler"] = sepettekiUrunler;
                        foreach (var item in sepettekiUrunler)
                            toplam = toplam + (item.Fiyati * item.SepettekiUrunAdedi);
                        return Json(new {toplam = toplam, success = "basarili", mesaj = "Başarıyla silindi." });
                    }
                }
                return Json(new {toplam = toplam, success = "basarisiz", mesaj = "İşlem sırasında bir hata ile karşılaşıldı. Lütfen sayfayı yeniledikten sonra tekrar deneyiniz." });
            }
            catch (Exception ex)
            {
                return Json(new { toplam = toplam, success = "basarisiz", mesaj = "İşlem sırasında bir hata ile karşılaşıldı. Lütfen sayfayı yeniledikten sonra tekrar deneyiniz." });
            }
        }

    }
}