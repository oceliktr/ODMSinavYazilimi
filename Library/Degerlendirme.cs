using ODMSinavYazilimi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ODMSinavYazilimi.Library
{
    public static class DegerlendirmeSinifi
    {
        public static int DogruYanlisOrani(int sinif)
        {
            return sinif >= 9 ? 4 : 3;
        }
        
        public static decimal ToplamKatsayiPuani(List<TestBransInfo> branslarList,List<TestSorularInfo> sorularList)
        {
            decimal toplamKatsayiPuani = 0;
            foreach (var b in branslarList)
            {
                var soruSayisi = sorularList.Count(x => x.BransId == b.Id);
                toplamKatsayiPuani += soruSayisi * b.KatSayi;
            }

            return toplamKatsayiPuani;
        }
        public static decimal PuanHesapla(int sinifi, int puanlama, decimal toplamBransPuan, decimal toplamKatsayiPuani)
        {
            decimal toplamPuan = 0;
            decimal lgsKatSayi = (decimal)193.4920;

            if (puanlama == 500)
            {
                if (sinifi >= 5 && sinifi <= 8)
                {
                    toplamPuan = toplamBransPuan + lgsKatSayi; //LGS
                   // toplamPuan = toplamBransPuan * 500 / +toplamKatsayiPuani; //ESKİ HESAP
                }
                if (sinifi >= 9 && sinifi <= 12)
                    toplamPuan = 100 + toplamBransPuan; //TYT puan hesaplama 
            }
            else
            {
                //katsayı hesabına göre puanlama
                toplamPuan = (toplamBransPuan * puanlama) / toplamKatsayiPuani;
            }

            return toplamPuan;
        }


    }
}
