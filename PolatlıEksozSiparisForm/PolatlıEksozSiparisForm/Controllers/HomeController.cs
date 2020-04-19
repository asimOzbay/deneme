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
            return View();
        }
         public ActionResult Contact()
        {
            return View();
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
                var urun = db.Urun.FirstOrDefault(x => x.ID == ID);
                var eklenecekUrunVM = new SepetVM { ID = urun.ID, Adi = urun.Adi, Fiyati = urun.Fiyati, SepettekiUrunAdedi = 1};

                if (Session["SepettekiUrunler"] != null && Session["SepetUrunAdedi"] != null)
                {
                    liste = (List<SepetVM>)Session["SepettekiUrunler"];
                    if (liste.Any(x => x.ID == ID))
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
                return Json(new { sonuc = "basarisiz", message = "ürün sepete eklendi" });
            }
        }

    }
}