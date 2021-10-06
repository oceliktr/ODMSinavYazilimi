using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
    public class TestSinavlarInfo
    {
        public int Id { get; set; }
        public int DonemId { get; set; }
        public int Sinif { get; set; }
        public int Puanlama { get; set; }
        public string SinavAdi { get; set; }
        public int Aktif { get; set; }
        public int Manuel { get; set; }
        public TestSinavlarInfo()
        {

        }
        public TestSinavlarInfo(int id, string sinavAdi)
        {
            Id = id;
            SinavAdi = sinavAdi;
        }
    }
}
