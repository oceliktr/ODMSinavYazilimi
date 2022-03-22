using ODMSinavYazilimi.Models;
using System;

namespace ODMSinavYazilimi.Library
{
    public static class Bellek
    {
        public static int DonemId { get; set; }

        public static TestSinavlarInfo SeciliSinav = new TestSinavlarInfo() { Id = 0, Sinif = 0 };

        public static string Dizin = AppDomain.CurrentDomain.BaseDirectory + "File";

        public static string AktifDonemveSinavlarUrl = "http://erzurumodm.meb.gov.tr/Kutuphaneler/AktifSinav.ashx";
        public static string AktifDonemveSinavlarFilename = Dizin + "\\AktifSinav.json";

        public static string BranslarUrl = "http://erzurumodm.meb.gov.tr/Kutuphaneler/Branslar.ashx?api=[APICODE]";
        public static string BranslarFilename = Dizin + "\\Branslar.json";

        public static string KutukFileNameGet(int sinavId, int sinif)
        {
            return Dizin + "\\" + sinavId + "_" + sinif + "_kutuk.json";
        }
        public static string KutukUrlGet(int donemId, int sinif)
        {
            return string.Format("http://erzurumodm.meb.gov.tr/Kutuphaneler/KutukList.ashx?donem={0}&sinif={1}&api=[APICODE]", donemId, sinif);
        }
        public static string SorularFileNameGet(int sinavId)
        {
            return Dizin + "\\" + sinavId + "_sorular.json";
        }
        public static string SorularUrlGet(int sinav)
        {
            return string.Format("http://erzurumodm.meb.gov.tr/Kutuphaneler/Sorular.ashx?api=[APICODE]&sinav={0}", sinav);
        }
        public static string ABKitapcikSorularFileNameGet(int sinavId)
        {
            return Dizin + "\\" + sinavId + "_abkitapciksorular.json";
        }
        public static string TestOgrCevaplarFileNameGet(int sinavId)
        {
            return Dizin + "\\" + sinavId + "_testogrcevaplar.json";
        }
        public static string TestOgrPuanlarFileNameGet(int sinavId)
        {
            return Dizin + "\\" + sinavId + "_testogrpuanlar.json";
        }
        public static string TestOkulPuanlarFileNameGet(int sinavId)
        {
            return Dizin + "\\" + sinavId + "_testokulpuanlar.json";
        }
        public static string TestIlcePuanlarFileNameGet(int sinavId)
        {
            return Dizin + "\\" + sinavId + "_testilcepuanlar.json";
        }
        public static string DersBazliCevaplariFileNameGet(int sinavId)
        {
            return Dizin + "\\" + sinavId + "_dersbazli_cevaplari.json";
        }

        public static string TestOgrCevaplarSqlFileNameGet(int sinavId,string dizinAdresi)
        {
            return dizinAdresi + "\\sql_" + sinavId + "_testogrcevaplar.sql";
        }
        public static string TestOgrPuanlarSqlFileNameGet(int sinavId, string dizinAdresi)
        {
            return dizinAdresi + "\\sql_" + sinavId + "_testogrpuanlar.sql";
        }
        public static string TestOkulPuanlarSqlFileNameGet(int sinavId, string dizinAdresi)
        {
            return dizinAdresi + "\\sql_" + sinavId + "_testokupuanlar.sql";
        }
        public static string TestIlcePuanlarSqlFileNameGet(int sinavId, string dizinAdresi)
        {
            return dizinAdresi + "\\sql_" + sinavId + "_testilcepuanlar.sql";
        }
    }
}
