using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
    public class OgrenciCevapModel: TestKutukInfo
    {
        public decimal Puan { get; set; }
        public decimal Net { get; set; }
        public List<DersCevap> DersCevaplari { get; set; }
    }

    public class DersCevap
    {
        public string KitapcikTuru { get; set; }
        public int DersId { get; set; }
        public string Cevaplar { get; set; }
        public int Dogru { get; set; }
        public int Yanlis { get; set; }
        public int Bos { get; set; }
        public decimal Net { get; set; }
    }
}
