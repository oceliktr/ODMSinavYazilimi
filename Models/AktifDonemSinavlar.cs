using System.Collections.Generic;

namespace ODMSinavYazilimi.Models
{
    public class AktifDonemSinavlar
    {
        public TestDonemInfo DonemInfo { get; set; }
        public List<TestSinavlarInfo> Sinavlar { get; set; }
        public List<TestOturumlarInfo> Oturumlar { get; set; }
    }
}
