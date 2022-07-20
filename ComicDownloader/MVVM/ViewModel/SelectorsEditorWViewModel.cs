using ComicDownloader.Core;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComicDownloader.MVVM.ViewModel
{
    internal class SelectorsEditorWViewModel : BaseViewModel
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
        public ICommand ConfirmCommand { get; set; }
        #endregion
        public SelectorsEditorWViewModel()
        {
            ConfirmCommand = new RelayCommand<Button>(p => true, EditSelectors);
        }
        public SelectorsEditorWViewModel(WebsiteInformation css)
        {
            Website = css.Referer;
            NextPageButtonSelector = css.Comics.NextPageButtonSelector;
            UrlComicsSelector = css.Comics.UrlComicsSelector;
            NameComicSelector = css.Comic.NameComicSelector;
            ChaptersComicSelector = css.Comic.ChaptersComicSelector;
            ImagesChapterSelector = css.Chapter.ImagesChapterSelector;

            ConfirmCommand = new RelayCommand<Button>(p => true, EditSelectors);
        }
        void EditSelectors(Button p)
        {
            string filePath = Variables.DataFilePath;
            WebsiteInformation[] csses = JsonHelper.GetDeserializeJsonFromWebsitesData(filePath);
            int length = csses.Length;
            for(int i = 0; i < length; i++)
            {
                if(csses[i].Referer != Website)
                {
                    continue;
                }
                csses[i].Comics.NextPageButtonSelector = NextPageButtonSelector;
                csses[i].Comics.UrlComicsSelector = UrlComicsSelector;
                csses[i].Comic.NameComicSelector = NameComicSelector;
                csses[i].Comic.ChaptersComicSelector = ChaptersComicSelector;
                csses[i].Chapter.ImagesChapterSelector = ImagesChapterSelector;
            }
            JsonHelper.SerializeAndSaveJson(csses, filePath);
            Window.GetWindow(p).Close();
        }
    }
}
