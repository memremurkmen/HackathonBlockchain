using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;

namespace MVCKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        KitapDBIslemleri ktpDb = new KitapDBIslemleri();
        public ActionResult Index(string p)
        {
            ViewBag.kitapSayisi = ktpDb.getKitapCount();//veritabanında kaç kitap olduğunu çekip kitapSayisi viewbag ine atıyoruz
            return View(ktpDb.getAllKitap(p));
        }

        [HttpGet]
        public ActionResult Index2(string baslangic, string bitis)//kitapları basım yıllarına göre filtreleyip listeliyor
        {
            if (baslangic != "" && bitis != "")
            {
                return View("Index", ktpDb.getAllKitapByBasimYili(baslangic, bitis));
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.tblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from y in db.tblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD + ' ' + y.SOYAD,
                                               Value = y.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(tblKitap p)
        {
            ktpDb.addKitap(p);
            return View("KitapEkle");
        }

        public ActionResult KitapSil(int id)
        {
            ktpDb.deleteKitap(id);
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {

            List<SelectListItem> deger1 = (from i in db.tblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.tblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktpDb.getKitapById(id));
        }

        public ActionResult KitapGuncelle(tblKitap p)
        {
            ktpDb.updateKitap(p);
            return RedirectToAction("Index");
        }
    }
}