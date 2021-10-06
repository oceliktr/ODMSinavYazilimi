using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
  public  class SoruSiralari
    {
        public string DersAdi { get; set; }
        public int OturumNo { get; set; }
        public int BransId { get; set; }
        public int ASoruNo { get; set; }
        public int BSoruNo { get; set; }

        public SoruSiralari(string dersAdi,int oturumNo, int bransId, int aSoruNo, int bSoruNo)
        {
            OturumNo = oturumNo;
            ASoruNo = aSoruNo;
            BSoruNo = bSoruNo;
            BransId = bransId;
            DersAdi = dersAdi;
        }

        public SoruSiralari()
        {
        }
    }
}
