using PolatlıEksozSiparisForm.Models.Context;
using PolatlıEksozSiparisForm.Models.Entity;
using PolatlıEksozSiparisForm.Models.VMs;
using PolatlıEksozSiparisForm.Sifreleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            ContextDB db = new ContextDB();
            var urun = db.Urun.FirstOrDefault(x => x.Fiyati > 10);
            var satici = db.Users.FirstOrDefault(x => x.ID == urun.UserID);

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

            string ekranaBasilacakYazi = urun.Adi + " " + urun.Users.Adi + " tarafından " + urun.Fiyati + "ye satılmaktadır.";

            //db den gelen liste SelectListItem listesine atıldıktan sonra son hali tempdata ile cshtml e atılıyor. (Login/Index sayfasında kullanıldı)
            TempData["kategoriListesi"] = kategoriListesi;
            return View();
        }
        //selected içerisinde seçilen verinin idsi gelmektedir.
        [HttpPost]
        public ActionResult LoginPost(userVM vm)
        {
            Users user = new Users {Email = vm.Email, Sifre = vm.Sifre};
            ContextDB db = new ContextDB();
            var dbMusteri = db.Users.FirstOrDefault(x => x.Email == vm.Email);
            
            sifre sifre = new sifre();

            Session["Giriş"] = dbMusteri.Adi + " " + dbMusteri.Soyadi;

            if ( dbMusteri == null )
            {
                TempData["Message"] = "Kayıt Bulunamadı";
                TempData["Success"] = false;
                return RedirectToAction("Index");
            }
            else if(sifre.VerifyHash(vm.Sifre, dbMusteri.Sifre) == false)
            {
                TempData["Message"] = "Şifre Yanlış";
                TempData["Success"] = false;
                return RedirectToAction("Index");
            }
            else if (vm.Email == "asmzby@gmail.com" && sifre.VerifyHash(vm.Sifre, dbMusteri.Sifre) == true)
            {
                TempData["Success"] = true;
                Session["Admin"] = "Ürün Ekle";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Success"] = true;
                
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
         public ActionResult RegisterPost(userVM vm)
        {
            if (vm.Sifre == vm.SifreTekrari || vm.Sifre != null)
            {
            sifre sifre = new sifre();
            var sifrelenmis = sifre.GetHash(vm.Sifre);
            Users user = new Users { Adi = vm.Adi, Soyadi = vm.Soyadi, Email = vm.Email, Sifre = sifrelenmis };
            ContextDB db = new ContextDB();
            db.Users.Add(user);
            db.SaveChanges();

                TempData["Message"] = "Kayıt Başarılı";
                TempData["Success"] = true;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Şifreler aynı olmalıdır";
                TempData["Success"] = false;
                return RedirectToAction("Register");
            }
        }

    }
}