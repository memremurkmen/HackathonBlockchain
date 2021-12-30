using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HareketDBIslemleri
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public List<tblHareket> getAllHareket()//veritabanında bulunan tblHareket tablosundaki bütün verileri çekiyor
        {
            return db.tblHareket.ToList();
        }

        public List<tblHareket> getAllHareketByIslemDurum(bool islemDurum)//işlem durumuna göre veritabanından verileri çekiyor
        {
            return db.tblHareket.Where(i => i.ISLEMDURUM == islemDurum).ToList();
        }

        public List<tblHareket> getAllHareketByIslemturu(string islemTuru)//işlem durumuna göre veritabanından verileri çekiyor
        {
            return db.tblHareket.Where(i => i.ISLEMTURU == islemTuru).ToList();
        }

        public List<tblHareket> getAllHareketByDay(DateTime day)//parametre olarak gönderilen tarihteki hareket verilerini çekiyor
        {
            return db.tblHareket.SqlQuery("dbo.guneGoreHareketCek {0}", day).ToList();//Stored Procedure kullanımı
        }

        public tblHareket getHareketById(int id)//idye göre veri çekiyor
        {
            return db.tblHareket.Find(id);
        }

        public void addAlisIslem(tblHareket h)//tblHareket tablosuna veri ekleniyor
        {
            db.tblHareket.Add(h);
            db.SaveChanges();
        }

        public void addIadeIslem(tblHareket h)//tblHareket tablosuna veri ekleniyor
        {
            updateAlisIslem(h);
            tblHareket iade = new tblHareket();
            var hrkt = db.tblHareket.Find(h.ID);
            iade.KITAP = hrkt.KITAP;
            iade.UYE = hrkt.UYE;
            iade.PERSONEL = hrkt.PERSONEL;
            iade.ISLEMTARIHI = DateTime.Now;
            iade.ISLEMTURU = "iade";
            iade.ISLEMDURUM = true;
            db.tblHareket.Add(iade);
            db.SaveChanges();
        }

        public void updateAlisIslem(tblHareket h)
        {
            var islem = db.tblHareket.Find(h.ID);
            islem.ISLEMDURUM = true;
            db.SaveChanges();
        }

        public List<tblHareket> getHareketByUyeId(int id)//idsi gönderilen üyenin bütün işlemlerini çekiyor
        {
            return db.tblHareket.Where(i => i.UYE == id).ToList();
        }
    }
}
