using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;

namespace MVCKutuphane.Controllers
{
    
    public class OduncController : Controller
    {
        // GET: Odunc
        //DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        HareketDBIslemleri hrktDb = new HareketDBIslemleri();
        public ActionResult Index()
        {
            return View(hrktDb.getAllHareketByIslemDurum(false));//iadesi yapılmamış hareketleri listeliyor
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(tblHareket h)
        {
            hrktDb.addAlisIslem(h);
            return RedirectToAction("Index");
        }

        public ActionResult Oduncİade(tblHareket h)
        {
            return View("Oduncİade", hrktDb.getHareketById(h.ID));
        }

        public ActionResult OduncGuncelle(tblHareket h)
        {
            hrktDb.addIadeIslem(h);
            return RedirectToAction("Index");
        }
    }
}