using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComicDownloader.Helper
{
    public static class HttpHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static int DownloadingTask = 0;
        public static int DownloadingTaskLimit = 5;

        public static void DownloadFile(string uri, string outputPath, string referer = null, string userAgent = null)
        {
            Uri uriResult;
            bool haveReferer = !(referer is null);
            bool haveUserAgent = !(userAgent is null);

            if (haveReferer || haveUserAgent)
            {
                _httpClient.DefaultRequestHeaders.Clear();
            }
            if (haveReferer && _httpClient.DefaultRequestHeaders.Referrer == null)
            {
                //_httpClient.DefaultRequestHeaders.Add("Referer", referer);
                _httpClient.DefaultRequestHeaders.Referrer = new Uri(referer);
            }
            if (haveUserAgent)
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
            }
            if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
                throw new InvalidOperationException("URI is invalid.");

            //throw new FileNotFoundException("File not found."
            //, nameof(outputPath));
            DownloadFileRecurse(outputPath, uri);
        }
        private static async void DownloadFileRecurse(string outputPath, string uri)
        {
            while (DownloadingTask >= DownloadingTaskLimit)
            {
                await Task.Delay(1000);
            }
            if (!File.Exists(outputPath))
            {
                File.Create(outputPath).Close();
            }
            Task<byte[]> fileBytesTask = _httpClient.GetByteArrayAsync(uri);
            DownloadingTask++;
            fileBytesTask.ContinueWith(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                {
                    DownloadFileRecurse(outputPath, uri);
                }
                else
                {
                    File.WriteAllBytes(outputPath, t.Result);
                    DownloadingTask--;
                }
            });
        }

        public static Task<string> DownloadStringAsync(string uri, string referer = null, string userAgent = null)
        {
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

            return _httpClient.GetStringAsync(uri);
        }
        public static void Dispose()
        {
            _httpClient.Dispose();
        }
    }

}
