using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Core
{
    public class Chapter
    {
        public string[] ImageUrls { get; set; }
        public string Name { get; set; }
        public Comic Comic { get; set; }
    }
}
