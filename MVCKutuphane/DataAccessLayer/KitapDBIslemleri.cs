using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KitapDBIslemleri
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public List<tblKitap> getAllKitap(string p)//tblKitap tablosundaki bütün verileri çekiyor
        {
            var kitaplar = from k in db.tblKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));//(parametre olarak gönderilen değer kitap adına göre filtreleme yapıyor)
            }
            return kitaplar.ToList();
        }

        public int getKitapCount()//veritabanındaki kitap sayısını döndürüyor
        {
            return db.Database.SqlQuery<int>("select dbo.fn_kitap_sayisi() as kitapSayisi").FirstOrDefault(); //fonksiyon kullanıyoruz.
        }

        public List<tblKitap> getAllKitapByBasimYili(string baslangic,string bitis)//tblKitap tablosundaki bütün verileri çekiyor
        {
            return db.tblKitap.SqlQuery("basimYilAraligiFiltre @baslangic = "+ baslangic + ", @bitis = "+ bitis).ToList(); //stored Procedure kullanıyoruz.
        }

        public void addKitap(tblKitap p)//tabloya yeni kitap ekliyor
        {
            var ktg = db.tblKategori.Where(k => k.ID == p.tblKategori.ID).FirstOrDefault();
            var yzr = db.tblYazar.Where(y => y.ID == p.tblYazar.ID).FirstOrDefault();
            p.tblKategori = ktg;
            p.tblYazar = yzr;
            db.tblKitap.Add(p);
            db.SaveChanges();
        }

        public void deleteKitap(int id)//tablodan kitap siliyor
        {
            db.tblKitap.Remove(db.tblKitap.Find(id));
            db.SaveChanges();
        }
        public tblKitap getKitapById(int id)//idye göre kitap çekiyor
        {
            return db.tblKitap.Find(id);
        }
        public void updateKitap(tblKitap p)//kitabı güncelliyor
        {
            var ktp = db.tblKitap.Find(p.ID);
            ktp.AD = p.AD;
            ktp.BASIMYIL = p.BASIMYIL;
            ktp.SAYFA = p.SAYFA;
            ktp.DURUM = true;
            ktp.YAYINEVI = p.YAYINEVI;

            var ktg = db.tblKategori.Where(k => k.ID == p.tblKategori.ID).FirstOrDefault();
            var yzr = db.tblYazar.Where(y => y.ID == p.tblYazar.ID).FirstOrDefault();
            ktp.tblKategori = ktg;
            ktp.tblYazar = yzr;

            db.SaveChanges();
        }
    }
}
