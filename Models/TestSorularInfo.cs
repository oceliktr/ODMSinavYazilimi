using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
    public class TestSorularInfo
    {
        public int Id { get; set; }
        public int OturumId { get; set; }
        public int BransId { get; set; }
        public int SoruNo { get; set; }
        public string Cevap { get; set; }
        public int Iptal { get; set; }

    }
    public class TestSorularViewModel
    {
        public int Id { get; set; }
        public string Oturum { get; set; }
        public string DersAdi { get; set; }
        public int SoruNo { get; set; }
        public string Cevap { get; set; }
        public string Iptal { get; set; }

    }
}
