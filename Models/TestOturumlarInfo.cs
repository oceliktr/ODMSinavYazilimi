using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
    public class TestOturumlarInfo
    {
        public int Id { get; set; }
        public int SinavId { get; set; }
        public int SiraNo { get; set; }
        public int Sure { get; set; }
        public string OturumAdi { get; set; }

        public TestOturumlarInfo()
        {
            
        }
        public TestOturumlarInfo(int id, string oturumAdi)
        {
            Id = id;
            OturumAdi = oturumAdi;
        }
    }
}
