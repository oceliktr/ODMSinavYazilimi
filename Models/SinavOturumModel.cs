using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
  public  class SinavOturumModel
    {
        public int SinavId { get; set; }
        public int OturumId { get; set; }
        public string SinavAdi { get; set; }
        public int SiraNo { get; set; }
        public string OturumAdi { get; set; }
        public int Sinif { get; set; }
        public int Sure { get; set; }
        public int Puanlama { get; set; }
    }
}
