using DataAccessLayer.Model.Class;
using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class YazarDBIslemleri
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public List<getAllYazar> getAllYazar()//tblYazar tablosundaki bütün verileri çekiyor
        {
            return db.Database.SqlQuery<getAllYazar>("select * from getAllYazar").ToList();//view kullanımı
        }

        public void addYazar(tblYazar k)//tblYazar tablosuna veri ekliyor
        {
            db.tblYazar.Add(k);
            db.SaveChanges();
        }

        public void deleteYazar(int id)//tablodan veri siliyor
        {
            db.tblYazar.Remove(db.tblYazar.Find(id));
            db.SaveChanges();
        }
        public tblYazar getYazarById(int id)//idye göre yazar bilgisi çekiyor
        {
            return db.tblYazar.Find(id);
        }
        public void updateYazar(tblYazar y)//yazar bilgisi güncelliyor
        {
            var yzr = db.tblYazar.Find(y.ID);
            yzr.AD = y.AD;
            yzr.SOYAD = y.SOYAD;
            yzr.DETAY = y.DETAY;
            db.SaveChanges();
        }
    }
}
