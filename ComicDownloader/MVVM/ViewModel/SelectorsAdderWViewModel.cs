using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using ComicDownloader.Core;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using ComicDownloader.Helper;
using MVVM.ViewModel;
using ComicDownloader.MVVM.View;
using System.Text.RegularExpressions;

namespace ComicDownloader.MVVM.ViewModel
{
    public class SelectorsAdderWViewModel : SelectorsAdderAndEditor
    {
        public SelectorsAdderWViewModel()
        {
            ConfirmCommand = new RelayCommand<Button>(p => true, SaveSelectors);
            Website = "";
            NextPageButtonSelector = "";
            ComicUrlsSelector = "";
            ComicNameSelector = "";
            ComicChaptersSelector = "";
            ChapterImagesSelector = "";
        }
        void SaveSelectors(Button p)
        {
            string filePath = Variables.DataFilePath;
            WebsiteInformation[] csses = JsonHelper.GetDeserializeJsonFromFile<WebsiteInformation[]>(filePath);
            WebsiteInformation css = new WebsiteInformation();
            css.Comics.NextPageButtonSelector = NextPageButtonSelector;
            css.Comics.ComicUrlsSelector = ComicUrlsSelector;
            css.Comic.ComicNameSelector = ComicNameSelector;
            css.Comic.ComicChaptersSelector = ComicChaptersSelector;
            css.Chapter.ChapterImagesSelector = ChapterImagesSelector;
            css.Url = Website;
            JsonHelper.SerializeAndSaveJson(csses.Append(css), filePath);
            Window.GetWindow(p).Close();
        }
    }
}
