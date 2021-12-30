using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PersonelDBIslemleri
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public List<tblPersonel> getAllPersonel()//tblPersonel tablosundaki verileri çekiyor
        {
            return db.tblPersonel.ToList();
        }

        public void addPersonel(tblPersonel k)//tblPersonel tablosuna veri ekliyor
        {
            db.tblPersonel.Add(k);
            db.SaveChanges();
        }

        public void deletePersonel(int id)//tblPersonel tablosundan veri siliyor
        {
            db.tblPersonel.Remove(db.tblPersonel.Find(id));
            db.SaveChanges();
        }
        public tblPersonel getPersonelById(int id)//id ye göre personel bilgisi çekiyor
        {
            return db.tblPersonel.Find(id);
        }
        public void updatePersonel(tblPersonel k)//personel bilgisi güncelliyor
        {
            var prsnl = db.tblPersonel.Find(k.ID);
            prsnl.PERSONEL = k.PERSONEL;
            db.SaveChanges();
        }
    }
}
