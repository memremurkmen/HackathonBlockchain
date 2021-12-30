using DataAccessLayer;
using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        UyeDBIslemleri uyeDb = new UyeDBIslemleri();
        // GET: KayitOl
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(tblUyeler u)
        {
            uyeDb.addUye(u);
            return View();
        }
    }
}