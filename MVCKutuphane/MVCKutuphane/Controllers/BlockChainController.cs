using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Model.Entity;
using DataAccessLayer.Model.Class;
using BlockChainLayer;

namespace MVCKutuphane.Controllers
{
    public class BlockChainController : Controller
    {
        //DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        BlockChainDBIslemleri blckDb = new BlockChainDBIslemleri();
        HareketDBIslemleri hrktDb = new HareketDBIslemleri();
        BlockchainIslemleri blckIslem = new BlockchainIslemleri();
        // GET: BlockChain
        public ActionResult Index()
        {
            var blocks = blckDb.getAllBlock();//veritabanından blokları çekiyor
            Blockchain blockchain = blckIslem.loadChain();//blokları blockchain classının içindeki chain zincirine ekliyor
            if (blockchain.isChainValid())//blockchain kontrolü
            {
                ViewBag.chainControl = "zinciri tam";
            }
            else
            {
                ViewBag.brokenBlockIndex = blockchain.brokenBlockIndex;
                ViewBag.chainControl = "zinciri kopuk";
            }
            return View(blocks);
        }

        [HttpGet]
        public ActionResult Index2()//günü bitir butonuna basıldığında
        {
            List<tblHareket> transactions = hrktDb.getAllHareketByDay(DateTime.Now);//bugün eklenen işlemleri hareket tablosundan çekiyor
            string transactionString = "";
            for (int i = 0; i < transactions.Count; i++)//verileri birleştirip block datasına koymak üzere birleştiriyoruz
            {
                transactionString += (transactions[i].UYE.ToString() + transactions[i].KITAP.ToString() + transactions[i].PERSONEL.ToString() + transactions[i].ISLEMTARIHI.ToString() + transactions[i].ISLEMTURU);
            }
            blckDb.addBlock(transactionString);//blok ekliyoruz
            return RedirectToAction("Index");
        }


    }
}