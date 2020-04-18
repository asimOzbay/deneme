using PolatlıEksozSiparisForm.Models.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Controllers
{
    public class BaseController : Controller
    {
        public MemoryCacheManager SesionHelper;
        public BaseController() : base() {
            SesionHelper = new MemoryCacheManager();
        }
    }
}