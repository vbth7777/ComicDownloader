using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Core
{
    public class ComicsSelectors
    {
        public string ComicUrlsSelector { get; set; }
        public string NextPageButtonSelector { get; set; }
    }
    public class ComicSelectors
    {
        public string ComicNameSelector { get; set; }
        public string ComicChaptersSelector { get; set; }
    }
    public class ChapterSelectors
    {
        public string ChapterImagesSelector { get; set; }
    }
    public class WebsiteInformation
    {
        public string Url { get; set; }
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
