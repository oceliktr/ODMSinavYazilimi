using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODMSinavYazilimi.Models;

namespace ODMSinavYazilimi.Library
{
   public class SinavBranslar
    {
        public List<TestBransInfo> SinavinBranslari(List<TestOturumlarInfo> oturumlar,List<TestBransInfo> branslarList, List<TestSorularInfo> sorularList)
        {
            List<TestBransInfo> branslar = new List<TestBransInfo>();
            foreach (var oturum in oturumlar.OrderBy(x => x.SiraNo))
            {
                var oturumDersleri = sorularList.Where(x => x.OturumId == oturum.Id).ToList()
                    .GroupBy(x => x.BransId)
                    .Select(x => x.First()).OrderBy(x => x.SoruNo).ToList();
                foreach (var brans in oturumDersleri)
                {
                    var bransGet = branslarList.FirstOrDefault(x => x.Id == brans.BransId);
                    branslar.Add(bransGet);
                }
            }

            return branslar;
        }
    }
}
