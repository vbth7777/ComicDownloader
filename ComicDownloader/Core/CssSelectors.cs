using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Core
{
    public class ComicsSelectors
    {
        public string UrlComicsSelector { get; set; }
        public string NextPageButtonSelector { get; set; }
    }
    public class ComicSelectors
    {
        public string NameComicSelector { get; set; }
        public string ChaptersComicSelector { get; set; }
    }
    public class ChapterSelectors
    {
        public string ImagesChapterSelector { get; set; }
    }
    public class WebsiteInformation
    {
        public string Referer { get; set; }
        public Enums.WebsiteType WebsiteType { get; set; }
        public ComicsSelectors Comics { get; set; }
        public ComicSelectors Comic { get; set; }
        public ChapterSelectors Chapter { get; set; }
        public WebsiteInformation()
        {
            Comics = new ComicsSelectors();
            Comic = new ComicSelectors();
            Chapter = new ChapterSelectors();
        }
    }
}
