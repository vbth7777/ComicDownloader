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

namespace ComicDownloader.MVVM.ViewModel
{
    public class SelectorsAdderWViewModel : BaseViewModel
    {
        #region Properties
        private string _Website; 

        public string Website
        {
            get { return _Website; }
            set { _Website = value; OnPropertyChanged(); }
        }
        private string _NextPageButtonSelector; // a tag

        public string NextPageButtonSelector
        {
            get { return _NextPageButtonSelector; }
            set { _NextPageButtonSelector = value; OnPropertyChanged(); }
        }

        private string _UrlComicsSelector; // a tags

        public string UrlComicsSelector
        {
            get { return _UrlComicsSelector; }
            set { _UrlComicsSelector = value;  OnPropertyChanged(); }
        }
        private string _NameComicSelector; // element has text in innerText

        public string NameComicSelector
        {
            get { return _NameComicSelector; }
            set { _NameComicSelector = value; OnPropertyChanged();  }
        }
        private string _ChaptersComicSelector; // a tags

        public string ChaptersComicSelector
        {
            get { return _ChaptersComicSelector; }
            set { _ChaptersComicSelector = value; OnPropertyChanged();  }
        }
        private string _ImagesChapterSelector; // img tags

        public string ImagesChapterSelector
        {
            get { return _ImagesChapterSelector; }
            set { _ImagesChapterSelector = value; OnPropertyChanged();  }
        }

        #endregion
        #region Commands
        public ICommand SaveCommand { get; set; }
        #endregion
        public SelectorsAdderWViewModel()
        {
            SaveCommand = new RelayCommand<Button>(p => true, SaveSelectors);
            Website = "";
            NextPageButtonSelector = "";
            UrlComicsSelector = "";
            NameComicSelector = "";
            ChaptersComicSelector = "";
            ImagesChapterSelector = "";
        }
        void SaveSelectors(Button p)
        {
            string filePath = Variables.DataFilePath;
            WebsiteInformation[] csses = JsonHelper.GetDeserializeJsonFromWebsitesData(filePath);
            WebsiteInformation css = new WebsiteInformation();
            css.Comics.NextPageButtonSelector = NextPageButtonSelector;
            css.Comics.UrlComicsSelector = UrlComicsSelector;
            css.Comic.NameComicSelector = NameComicSelector;
            css.Comic.ChaptersComicSelector = ChaptersComicSelector;
            css.Chapter.ImagesChapterSelector = ImagesChapterSelector;
            css.Referer = Website;
            JsonHelper.SerializeAndSaveJson(csses.Append(css), filePath);
            Window.GetWindow(p).Close();
        }
    }
}
