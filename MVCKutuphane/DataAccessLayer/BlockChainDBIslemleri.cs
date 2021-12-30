using DataAccessLayer.Model.Class;
using DataAccessLayer.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlockChainDBIslemleri
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public List<tblBlock> getAllBlock()//veritabanında bulunan tblBlock tablosundaki bütün verileri çekiyor
        {
            return db.tblBlock.ToList();
        }

        public void addBlock(string transaction)//veritabanına yeni blok ekliyor
        {
            string lastBlockHash = db.Database.SqlQuery<string>("SELECT TOP 1 hash FROM tblBlock ORDER BY id DESC").FirstOrDefault();//veritabanındaki son bloğun hash i
            int lastBlockId = db.Database.SqlQuery<int>("SELECT TOP 1 id FROM tblBlock ORDER BY id DESC").FirstOrDefault();//veritabanındaki son bloğun id si
            tblBlock blck = new tblBlock();
            blck.id = lastBlockId + 1;
            blck.timestamp = DateTime.Now;
            blck.data = transaction;
            blck.hashPrev = lastBlockHash;
            blck.hash = SHA_256_Encrypting((blck.id).ToString() + blck.hashPrev + blck.timestamp.ToString() + blck.data);
            db.tblBlock.Add(blck);
            db.SaveChanges();
        }

        public static string SHA_256_Encrypting(string deger)
        {
            SHA256 sha = SHA256.Create();
            byte[] degerBytes = Encoding.UTF8.GetBytes(deger);
            byte[] shaBytes = sha.ComputeHash(degerBytes);
            return HashToByte(shaBytes);
        }
        public static string HashToByte(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            foreach (byte item in hash)
            {
                result.Append(item.ToString("x2"));

            }

            return result.ToString();
        }
    }
}
