using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;

namespace MVCKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        PersonelDBIslemleri prsnlDb = new PersonelDBIslemleri();
        public ActionResult Index()
        {
            return View(prsnlDb.getAllPersonel());
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(tblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            prsnlDb.addPersonel(p);
            return View();

        }

        public ActionResult PersonelSil(int id)
        {
            prsnlDb.deletePersonel(id);
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            return View("PersonelGetir", prsnlDb.getPersonelById(id));
        }

        public ActionResult PersonelGuncelle(tblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }
            prsnlDb.updatePersonel(p);
            return RedirectToAction("Index");
        }
    }
}