using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        UyeDBIslemleri uyeDb = new UyeDBIslemleri();
        HareketDBIslemleri hrktDb = new HareketDBIslemleri();

        [HttpGet]
        [Authorize]//autherization kullanımı
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnaSayfa()
        {
            return View();
        }

        public ActionResult Kitaplarim()
        {
            var uyeId = Convert.ToInt32(Session["ID"]);
            return View(hrktDb.getHareketByUyeId(uyeId).ToList());//sessionda tutulan uye idsine göre hareket bilgisi çekiyor
        }

       
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }


    }
}

   