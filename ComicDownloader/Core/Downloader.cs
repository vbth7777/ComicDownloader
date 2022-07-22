using ComicDownloader.Helper;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static ComicDownloader.Core.DownloadHelper;

namespace ComicDownloader.Core
{
    public static class DownloadHelper
    {
        public delegate void TaskDownloader(string name, float onePercent, object o = null);
        public static string GetHtmlString(string url, string referer = null)
        {
            //webClient.Headers.Clear();
            //webClient.Headers.Add(HttpRequestHeader.Referer, referer);
            //webClient.Headers.Add(HttpRequestHeader.UserAgent, userAgent);
            //return webClient.DownloadString(url);
            return HttpHelper.DownloadStringAsync(url, referer, Variables.UserAgent).Result;
        }
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static string GetValidDirectoryPath(string path)
        {
            if (!Regex.IsMatch(path, @"\\$"))
            {
                path += "\\";
            }
            return path;
        }
        public static string GetValidDirectoryName(string name)
        {
            return Regex.Replace(name.Trim(), "[\\\\/:*?\"<>|]|\\.+$", "");
        }
        public static HtmlNode GetDocumentNode(string url, string referer = null)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(GetHtmlString(url, referer));
            return doc.DocumentNode;
        }
        public static void ImageDownloader(string url, string path, string referer = null)
        {
            HttpHelper.DownloadFile(url, path, referer, Variables.UserAgent);
        }
        public static void ImagesDownloader(List<string> imageUrls, string path, string referer = null)
        {
            int count = 0;
            path = DownloadHelper.GetValidDirectoryPath(path);
            foreach (string imageUrl in imageUrls)
            {
                string filePath = path + count.ToString() + ".jpg";
                ImageDownloader(imageUrl, filePath, referer);
                count++;
            }
        }
    }
    public static class Downloader
    {
        public static void ChapterDownloader(string chapterUrl, WebsiteInformation cssSelectors, string path)
        {
            try
            {
                HtmlNode chapterNode = DownloadHelper.GetDocumentNode(chapterUrl);
                HtmlNode[] imageNodes = chapterNode.QuerySelectorAll(cssSelectors.Chapter.ImagesChapterSelector).ToArray();
                List<string> imageUrls = new List<string>();
                foreach (HtmlNode imageNode in imageNodes)
                {
                    if (imageNode.GetAttributeValue("src", null) is null)
                    {
                        throw new Exceptions.WrongTagElementException("Not img tag element");
                    }
                    string imageUrl = imageNode.GetAttributeValue("src", "");
                    if (Regex.IsMatch(imageUrl, @"^\/\/"))
                    {
                        imageUrl = "https:" + imageUrl;
                    }
                    if (imageUrl != "")
                    {
                        imageUrls.Add(imageUrl);
                    }
                }
                ImagesDownloader(imageUrls, path, cssSelectors.Url);
            }
            catch
            {
                ChapterDownloader(chapterUrl, cssSelectors, path);
            }
        }
        public static void ComicDownloader(string url, WebsiteInformation cssSelectors, string comicPath,
            TaskDownloader functionBeforeDownloadingComic = null,
            TaskDownloader functionBeforeDownloadingChapter = null)
        {
            comicPath = DownloadHelper.GetValidDirectoryPath(comicPath);
            HtmlNode comicNode = DownloadHelper.GetDocumentNode(url);
            string comicName = comicNode.QuerySelector(cssSelectors.Comic.NameComicSelector).InnerText.Trim();
            HtmlNode[] chapterNodes = comicNode.QuerySelectorAll(cssSelectors.Comic.ChaptersComicSelector).Reverse().ToArray();
            comicPath += DownloadHelper.GetValidDirectoryName(comicName) + "\\";
            DownloadHelper.CreateDirectory(comicPath);
            //List<string> chapterPaths = new List<string>();
            //List<string> chapterUrls = new List<string>();
            float onePercent = (float)1 / chapterNodes.Length * 100;
            functionBeforeDownloadingComic(comicName, onePercent);
            bool isFirstDownloading = false;
            foreach (HtmlNode chapterNode in chapterNodes)
            {
                if (chapterNode.GetAttributeValue("href", null) is null)
                {
                    throw new Exceptions.WrongTagElementException("Not a tag element");
                }
                string chapterUrl = HtmlEntity.DeEntitize(chapterNode.GetAttributeValue("href", ""));
                string chapterName = DownloadHelper.GetValidDirectoryName(chapterNode.InnerText);
                string chapterPath = comicPath + chapterName;
                //chapterPaths.Add(chapterPath);
                //chapterUrls.Add(chapterUrl);
                functionBeforeDownloadingChapter(chapterName, onePercent, isFirstDownloading);
                isFirstDownloading = true;
                DownloadHelper.CreateDirectory(chapterPath);
                ChapterDownloader(chapterUrl, cssSelectors, chapterPath);
            }
            //int pathsLength = chapterPaths.Count();
            //int urlsLength = chapterUrls.Count();
            //for(int i = 0; i < pathsLength || i < urlsLength; i++)
            //{
            //    if(!Directory.Exists(chapterPaths[i])) 
            //    {
            //        Directory.CreateDirectory(chapterPaths[i]); 
            //    }
            //    ChapterDownloader(chapterUrls[i], chapterPaths[i]);
            //}
        }
        public static void ComicsDownloader(string url, WebsiteInformation cssSelectors, string comicsPath,
            TaskDownloader functionBeforeDownloadingComic = null,
            TaskDownloader functionBeforeDownloadingChapter = null,
            TaskDownloader functionAfterDownloadedComics = null,
            TaskDownloader functionAfterDownloadedComic = null)
        {
            comicsPath = DownloadHelper.GetValidDirectoryPath(comicsPath);
            HtmlNode comicsNode = DownloadHelper.GetDocumentNode(url);
            while (true)
            {
                HtmlNode[] comicNodes = comicsNode.QuerySelectorAll(cssSelectors.Comics.UrlComicsSelector).ToArray();
                float onePercentComicOfPage = (float)1 / comicNodes.Length * 100;
                foreach (HtmlNode comicNode in comicNodes)
                {
                    string comicUrl = HtmlEntity.DeEntitize(comicNode.GetAttributeValue("href", null));
                    if (comicUrl is null)
                        continue;
                    ComicDownloader(comicUrl, cssSelectors, comicsPath, functionBeforeDownloadingComic, functionBeforeDownloadingChapter);
                    functionAfterDownloadedComic(null, onePercentComicOfPage);
                }
                functionAfterDownloadedComics(null, onePercentComicOfPage);
                string nextPageUrl = HtmlEntity.DeEntitize(comicsNode.QuerySelector(cssSelectors.Comics.NextPageButtonSelector).GetAttributeValue("href", null));
                if (nextPageUrl is null)
                    continue;
                comicsNode = DownloadHelper.GetDocumentNode(nextPageUrl);
            }
        }

    }
}
