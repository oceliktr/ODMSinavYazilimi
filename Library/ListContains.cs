using System;

namespace ODMSinavYazilimi.Library
{
    public static class ListContains
    {
        public static bool Contains(this string target, string value, StringComparison comparison)
        {
            return target.IndexOf(value, comparison) >= 0;
        }
    }
}
