using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Library
{
    public static class GenelIslemler
    {
        public static string IlkHarfleriBuyut(this string metin)
        {
            try
            {
                metin = metin.ToLower();
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                return textInfo.ToTitleCase(metin);
            }
            catch (Exception)
            {
                return metin;
            }
        }
        public static bool IsInteger(this object sayi)
        {
            try
            {
                if (sayi == null) throw new Exception();
                Convert.ToInt32(sayi);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static string SubeIsmiKisalt(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            string[] sube = s.Split('/');

            s = sube[1];
            s = s.Replace("Şubesi", "");
            s = s.Trim();
            return s;
        }
        public static string ToUrl(this string s)
        {
            //s = oncul + id + "-" + s;
            if (string.IsNullOrEmpty(s)) return "";
            s = s.ToLower().Trim();
            if (s.Length > 80)
                s = s.Substring(0, 80);
            s = s.Replace("ş", "s");
            s = s.Replace("Ş", "S");
            s = s.Replace("ğ", "g");
            s = s.Replace("Ğ", "G");
            s = s.Replace("İ", "I");
            s = s.Replace("ı", "i");
            s = s.Replace("ç", "c");
            s = s.Replace("Ç", "C");
            s = s.Replace("ö", "o");
            s = s.Replace("Ö", "O");
            s = s.Replace("ü", "u");
            s = s.Replace("Ü", "U");
            s = s.Replace("'", "");
            s = s.Replace("\"", "");
            s = s.Replace("-", "");
            s = s.Replace("'", "");
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            //if (r.IsMatch(s))
            s = r.Replace(s, "");
            if (!string.IsNullOrEmpty(s))
                while (s.IndexOf("--", StringComparison.Ordinal) > -1)
                    s = s.Replace("--", "");
            if (s.StartsWith("-")) s = s.Substring(1);
            if (s.EndsWith("-")) s = s.Substring(0, s.Length - 1);
            return s;
        }
        public static int ToInt32(this object sayi)
        {
            try
            {
                if (sayi == null) throw new Exception();
                int x = Convert.ToInt32(sayi);
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this object sayi)
        {
            try
            {
                if (sayi == null) throw new Exception();
                decimal x = Convert.ToDecimal(sayi);
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static long ToInt64(this object sayi)
        {
            try
            {
                if (sayi == null) throw new Exception();
                long x = Convert.ToInt64(sayi);
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static String RastgeleSayiUret(int adet)
        {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < adet; i++)
            {
                int a = random.Next();
                switch (a)
                {
                    case 0:
                        int c = 65 + random.Next(26);
                        s = String.Concat(s, Convert.ToString(c));
                        break;
                    default:
                        s = String.Concat(s, random.Next(10).ToString());
                        break;
                }
            }
            return s;
        }
        public static String RastgeleMetinUret(int adet)
        {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < adet; i++)
            {
                int a = random.Next(2);
                switch (a)
                {
                    case 0:
                        char c = Convert.ToChar(65 + random.Next(26));
                        s = String.Concat(s, Convert.ToString(c));
                        break;
                    default:
                        s = String.Concat(s, random.Next(10).ToString());
                        break;
                }
            }
            return s;
        }
        public static string SoldanMetinAl(this string metin, int uzunluk)
        {
            try
            {
                return metin.Length < uzunluk ? metin : metin.Substring(0, uzunluk);
            }
            catch (Exception)
            {
                return metin;
            }
        }
    }
}
