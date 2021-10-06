using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMSinavYazilimi.Models
{
   public class ResultList
    {
        public string Key { get; set; }
        public string Result { get; set; }

        public ResultList(string key, string result)
        {
            Key = key;
            Result = result;
        }
    }
}
