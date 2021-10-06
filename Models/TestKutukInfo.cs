using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
    public class TestKutukInfo
    {
        public int Id { get; set; }
        public string IlceAdi { get; set; }
        public int KurumKodu { get; set; }
        public string KurumAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Sinifi { get; set; }
        public string Sube { get; set; }
        public string Text { get; }
        public string Value { get; }

        public TestKutukInfo(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public TestKutukInfo()
        {
        }
    }
}
