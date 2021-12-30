using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DataAccessLayer.Model.Class
{
    public class Block
    {
        public int id { get; set; }
        public string timestamp { get; set; }
        public string data { get; set; }
        public string prevHash { get; set; }
        public string hash { get; set; }

        public Block() {}

        public Block(int id, string timestamp, string data, string prevHash)
        {
            this.id = id;
            this.timestamp = timestamp;
            this.data = data;
            this.prevHash = prevHash;
        }

        public string calculateHash()//bloğun verilerini şifreliyor
        {
            return SHA_256_Encrypting(this.id + this.prevHash + this.timestamp + this.data);
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