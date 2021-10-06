using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
    public class SinifSube
    {
        public int SiraNo { get; }
        public string IlceAdi { get; set; }
        public int KurumKodu { get; set; }
        public string KurumAdi { get; set; }
        public int Sinif { get; set; }
        public string Sube { get; set; }
        public int OgrenciSayisi { get; }

        public SinifSube(int siraNo, string ilceAdi, int kurumKodu, string kurumAdi, int sinif, string sube, int ogrenciSayisi)
        {
            SiraNo = siraNo;
            IlceAdi = ilceAdi;
            KurumKodu = kurumKodu;
            KurumAdi = kurumAdi;
            Sinif = sinif;
            Sube = sube;
            OgrenciSayisi = ogrenciSayisi;
        }
    }
}
