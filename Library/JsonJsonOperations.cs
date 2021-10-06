using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ODMSinavYazilimi.Library
{
 public class JsonOperations
    {
        public T GetJsonUrl<T>(string url)
        {
            T items;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string data = wc.DownloadString(url);

                items = JsonConvert.DeserializeObject<T>(data);
            }

            return items;
        }
        public List<T> GetListJsonUrl<T>(string url)
        {
            List<T> items;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string data = wc.DownloadString(url);

                items = JsonConvert.DeserializeObject<List<T>>(data);
            }

            return items;
        }
        public T GetJsonFile<T>(string fileName)
        {
            string jsonFile = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(jsonFile);
        }
        public List<T> GetListJsonFile<T>(string fileName)
        {
            string jsonFile = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<T>>(jsonFile);
        }
        public void JsonSaveFile(object val,string filename)
        {
            var json = JsonConvert.SerializeObject(val);
            File.WriteAllText(filename, json, Encoding.UTF8);
        }
    }
}
