using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;
namespace MVCKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        //DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        KategoriDBIslemleri ktgrDb = new KategoriDBIslemleri();
        // GET: Kategori
        public ActionResult Index()
        {
            return View(ktgrDb.getAllKategori());//bütün kategorileri çekip ön tarafa gönderiyor
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(tblKategori p)
        {
            ktgrDb.addKategori(p);
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            ktgrDb.deleteKategori(id);
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            return View("KategoriGetir", ktgrDb.getKategoriById(id));
        }

        public ActionResult KategoriGuncelle(tblKategori p)
        {
            ktgrDb.updateKategoriAd(p);
            return RedirectToAction("Index");

        }

    }
}