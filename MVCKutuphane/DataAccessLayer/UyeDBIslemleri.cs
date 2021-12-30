using DataAccessLayer.Model.Class;
using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UyeDBIslemleri
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public List<getAllUye> getAllUyeler()//bütün üyeleri veritabanından çekiyor.
        {
            return db.Database.SqlQuery<getAllUye>("select * from getAllUye").ToList();//view kullanımı
        }

        public int getUyeCount()//
        {
            return db.Database.SqlQuery<int>("select dbo.fn_uye_sayisi() as uyeSayisi").FirstOrDefault(); //fonksiyon kullanımı
        }

        public void addUye(tblUyeler u)//veritabanına üye ekliyor
        {
            db.tblUyeler.Add(u);
            db.SaveChanges();
        }

        public void deleteUye(int id)//veritabanından id sine göre üye siliyor.
        {
            db.tblUyeler.Remove(db.tblUyeler.Find(id));
            db.SaveChanges();
        }
        public tblUyeler getUyeByUyeId(int id)//üye id sine göre veritabanından üye çekiyor
        {
            return db.tblUyeler.Find(id);
        }
        public void updateUye(tblUyeler u)//veritabanındaki üye bilgisini güncelliyor
        {
            var uye = db.tblUyeler.Find(u.ID);
            uye.AD = u.AD;
            uye.SOYAD = u.SOYAD;
            uye.MAIL = u.MAIL;
            uye.KULLANICIADI = u.KULLANICIADI;
            uye.SIFRE = u.SIFRE;
            uye.TELEFON = u.TELEFON;
            uye.OKUL = u.OKUL;
            uye.TC = u.TC;
            uye.DOGUMYILI = u.DOGUMYILI;
            db.SaveChanges();
        }
        public tblUyeler getUyeByMailAndSifre(tblUyeler p)
        {
            return db.tblUyeler.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
        }
    }
}
