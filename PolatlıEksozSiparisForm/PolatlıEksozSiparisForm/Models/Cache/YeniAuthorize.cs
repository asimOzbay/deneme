using PolatlıEksozSiparisForm.Models.Context;
using PolatlıEksozSiparisForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolatlıEksozSiparisForm.Models.Cache
{
    public class YeniAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            MemoryCacheManager SessionHelper = new MemoryCacheManager();
            
            if (SessionHelper.Get<Users>("Kullanici") == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
    }
}