using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComicDownloader.Core
{
    public static class HttpHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static void DownloadFile(string uri, string outputPath, string referer = null, string userAgent = null)
        {
            Uri uriResult;
            bool haveReferer = !(referer is null);
            bool haveUserAgent = !(userAgent is null);
            if (haveReferer || haveUserAgent)
            {
                _httpClient.DefaultRequestHeaders.Clear();
            }
            if (haveReferer)
            {
                _httpClient.DefaultRequestHeaders.Add("Referer", referer);
            }
            if (haveUserAgent)
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
            }

            if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
                throw new InvalidOperationException("URI is invalid.");

            if (!File.Exists(outputPath))
            {
                File.Create(outputPath).Close();
            }
            //throw new FileNotFoundException("File not found."
            //, nameof(outputPath));
            byte[] fileBytes = _httpClient.GetByteArrayAsync(uri).Result;
            File.WriteAllBytes(outputPath, fileBytes);
        }
        public static Task<string> DownloadStringAsync(string uri, string referer = null, string userAgent = null)
        {
            bool haveReferer = !(referer is null);
            bool haveUserAgent = !(userAgent is null);
            if(haveReferer || haveUserAgent)
            {
                _httpClient.DefaultRequestHeaders.Clear();
            }    
            if(haveReferer)
            {
                _httpClient.DefaultRequestHeaders.Add("Referer", referer);
            }
            if(haveUserAgent)
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
            }

            return _httpClient.GetStringAsync(uri);
        }
        public static void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
