using ComicDownloader.Core;
using ComicDownloader.MVVM.View;
using ComicDownloader.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class SelectorsAdderAndEditor : BaseViewModel
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

        private string _ComicUrlsSelector; // a tags
        public string ComicUrlsSelector
        {
            get { return _ComicUrlsSelector; }
            set { _ComicUrlsSelector = value;  OnPropertyChanged(); }
        }

        private string _ComicNameSelector; // element has text in innerText
        public string ComicNameSelector
        {
            get { return _ComicNameSelector; }
            set { _ComicNameSelector = value; OnPropertyChanged();  }
        }

        private string _ComicChaptersSelector; // a tags
        public string ComicChaptersSelector
        {
            get { return _ComicChaptersSelector; }
            set { _ComicChaptersSelector = value; OnPropertyChanged();  }
        }

        private string _ChapterImagesSelector; // img tags
        public string ChapterImagesSelector
        {
            get { return _ChapterImagesSelector; }
            set { _ChapterImagesSelector = value; OnPropertyChanged();  }
        }

        #endregion
        #region Commands
        public ICommand ConfirmCommand { get; set; }
        public ICommand GetSelectorsCommand { get; set; }
        #endregion
        public SelectorsAdderAndEditor()
        {
            GetSelectorsCommand = new RelayCommand<object>(p => true, LoadSelectorsFromGetSelectorsButton);
        }
        void LoadSelectorsFromGetSelectorsButton(object p)
        {
            if (Website == "" || !Regex.IsMatch(Website, @"^https?:\/\/(www)?\.?.+"))
            {
                //alert
                MessageBox.Show("Valid website address");
                return;
            }
            SelectorsGetterWView getter = new SelectorsGetterWView(Website);
            getter.ShowDialog();
            WebsiteInformation selectors = (getter.DataContext as SelectorsGetterWViewModel).Selectors;
            
            ComicUrlsSelector = selectors.Comics.ComicUrlsSelector;
            NextPageButtonSelector = selectors.Comics.NextPageButtonSelector;
            ComicChaptersSelector = selectors.Comic.ComicChaptersSelector;
            ComicNameSelector = selectors.Comic.ComicNameSelector;
            ChapterImagesSelector = selectors.Chapter.ChapterImagesSelector;
        }
    }
}
