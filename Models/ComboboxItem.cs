using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
    public class ComboboxItem
    {

        public string Text { get; }
        public string Value { get; }

        public ComboboxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }
    }
}
