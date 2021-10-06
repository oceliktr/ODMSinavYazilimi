using System.Diagnostics;

namespace ODMSinavYazilimi.Library
{
    public static class KalanSure
    {
        public static string KalanSureHesapla(this int islemSayisi, int a, Stopwatch watch)
        {
            double kalanIslem = islemSayisi - a;
            double gecenSaniye = watch.Elapsed.TotalSeconds;
            double saniye = (kalanIslem * gecenSaniye) / a;

            double dakika = saniye / 60; //dakikamizin ilk degerini hesapladik
            saniye = saniye % 60; //son olarak saniyemizi mod alarak hesapliyoruz
            double saat = dakika / 60; //saat degerimizi hesapladik
            dakika = dakika % 60; //son olarak mod alarak dakikamizi hesapliyoruz

            string kalanSure =
                string.Format("Tahmini kalan süre : {0:00}:{1:00}:{2:00}", saat, dakika, saniye);
            return kalanSure;
        }
    }
}
