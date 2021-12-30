using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;

namespace MVCKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        YazarDBIslemleri yzrDb = new YazarDBIslemleri();
        public ActionResult Index()
        {
            return View(yzrDb.getAllYazar());
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(tblYazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            yzrDb.addYazar(p);
            return View();
        }

        public ActionResult YazarSil(int id)
        {
            yzrDb.deleteYazar(id);
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            return View("YazarGetir", yzrDb.getYazarById(id));
        }

        public ActionResult YazarGuncelle(tblYazar y)
        {
            yzrDb.updateYazar(y);
            return RedirectToAction("Index");
        }
    }
}