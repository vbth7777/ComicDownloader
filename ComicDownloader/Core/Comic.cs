using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Core
{
    public class Comic
    {
        public string Name { get; set; }
        public Chapter[] Chapters { get; set; }
    }
}
