using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
   public class OgrenciExcelModel
    {
        public int OpaqId { get; set; }
        public string Ilce { get; set; }
        public int KurumKodu { get; set; }
        public string KurumAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int OgrenciNo { get; set; }

        public int Sinif { get; set; }
        public string Sube { get; set; }
        public decimal OgrenciPuani { get; set; }
        public decimal ToplamNet { get; set; }
        public string OgrenciSonucStr { get; set; }

    }
}
