using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;

namespace ComicDownloader.Core
{
    public static class JsonHelper
    {
        private static void FileChecker(string filePath)
        {
            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                File.WriteAllText(filePath, "[]");
            }
        }
        public static void SerializeAndSaveJson(WebsiteInformation[] csses, string filePath)
        {
            string json = JsonConvert.SerializeObject(csses, Formatting.Indented);
            if(json == "" || json is null)
            {
                //alert
                MessageBox.Show("Unvalid");
                return;
            }
            File.WriteAllText(filePath, json);
        }
        public static void SerializeAndSaveJson(IEnumerable<WebsiteInformation> csses, string filePath)
        {
            string json = JsonConvert.SerializeObject(csses, Formatting.Indented);
            if (json == "" || json is null)
            {
                //alert
                MessageBox.Show("Unvalid");
                return;
            }
            File.WriteAllText(filePath, json);
        }
        public static WebsiteInformation[] GetDeserializeJsonFromWebsitesData(string filePath)
        {
            FileChecker(filePath);
            return JsonConvert.DeserializeObject<WebsiteInformation[]>(File.ReadAllText(filePath));
        }
    }
}
