using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Model.Class;
using DataAccessLayer.Model.Entity;

namespace BlockChainLayer
{
    public class BlockchainIslemleri//blockchainle ilgili işlemlerin bulunduğu class
    {
        BlockChainDBIslemleri blckDb = new BlockChainDBIslemleri();
        public Blockchain loadChain()//veritabanınkai blockları çekip zincir oluşturduğumuz method
        {
            var bloklar = blckDb.getAllBlock();
            Blockchain blockchain = new Blockchain();
            for (int i = 0; i < bloklar.Count; i++)
            {
                Block block = new Block(bloklar[i].id, bloklar[i].timestamp.ToString(), bloklar[i].data, bloklar[i].hashPrev);
                block.hash = bloklar[i].hash;
                blockchain.chain.Add(block);
            }
            return blockchain;
        }

        

    }
}
