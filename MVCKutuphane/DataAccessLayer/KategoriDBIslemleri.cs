using DataAccessLayer.Model.Class;
using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KategoriDBIslemleri
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public List<getAllKategori> getAllKategori()//tblKategori tablosundaki bütün verileri çekiyor
        {
            return db.Database.SqlQuery<getAllKategori>("select * from getAllKategori").ToList();//view kullanımı
        }

        public void addKategori(tblKategori k)//tblKategorisine veri ekliyor
        {
            db.tblKategori.Add(k);
            db.SaveChanges();
        }

        public void deleteKategori(int id)//tblKategori tablosundan gelen idye ait kategori siliniyor
        {
            db.tblKategori.Remove(db.tblKategori.Find(id));
            db.SaveChanges();
        }
        public tblKategori getKategoriById(int id)//kategori idsine göre kategori çekiyor
        {
            return db.tblKategori.Find(id);
        }
        public void updateKategoriAd(tblKategori k)//kategori adı güncelliyor
        {
            var ktg = db.tblKategori.Find(k.ID);
            ktg.AD = k.AD;
            db.SaveChanges();
        }

    }
}
