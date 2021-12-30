using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;
namespace MVCKutuphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        //DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        HareketDBIslemleri hrktDb = new HareketDBIslemleri();
        public ActionResult Index()
        {
            return View(hrktDb.getAllHareketByIslemturu("iade"));//iadesi yapılmış kitapları veritabanından çekip listelemesini sağlıyor
        }
    }
}