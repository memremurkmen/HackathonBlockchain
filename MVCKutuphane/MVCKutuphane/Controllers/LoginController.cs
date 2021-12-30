using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;

namespace MVCKutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        UyeDBIslemleri uyeDb = new UyeDBIslemleri();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblUyeler p)
        {
            if (p.MAIL == "admin" && p.SIFRE == "admin")//mail ve şifre admin olarak girildiyse admin sayfasına yönlendiriyor
            {
                return RedirectToAction("Index", "Kategori");
            }
            var bilgiler = uyeDb.getUyeByMailAndSifre(p);
            if (bilgiler != null)
            {//session işlemleri
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["MAIL"] = bilgiler.MAIL.ToString();
                Session["ID"] = bilgiler.ID.ToString();
                Session["AD"] = bilgiler.AD.ToString();
                Session["SOYAD"] = bilgiler.SOYAD.ToString();
                Session["KULLANICIADI"] = bilgiler.KULLANICIADI.ToString();
                Session["SIFRE"] = bilgiler.SIFRE.ToString();
                Session["TELEFON"] = bilgiler.TELEFON.ToString();
                Session["OKUL"] = bilgiler.OKUL.ToString();
                Session["TC"] = bilgiler.TC.ToString();
                Session["DOGUMYILI"] = bilgiler.DOGUMYILI.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
            
        }
    }
}