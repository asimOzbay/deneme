using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Controllers
{
    public class SiparisController : Controller
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

        public ActionResult Odeme()
        {
            return View();
        }
    }
}