using ComicDownloader.Core;
using System;
using System.Windows.Input;
using ComicDownloader.MVVM.View;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using ComicDownloader.Helper;

namespace ComicDownloader.MVVM.ViewModel
{
    public class DownloaderViewModel : BaseViewModel
    {
        #region DownloaderProperties
        private WebsiteInformation[] _Websites;
        public WebsiteInformation[] Websites
        {
            get { return _Websites; }
            set { _Websites = value; OnPropertyChanged(); }
        }

        private bool _IsEditSelectorsButtonEnable;
        public bool IsEditSelectorsButtonEnable
        {
            get { return _IsEditSelectorsButtonEnable; }
            set { _IsEditSelectorsButtonEnable = value; OnPropertyChanged(); }
        }

        private WebsiteInformation _SelectedWebsite;
        public WebsiteInformation SelectedWebsite
        {
            get { return _SelectedWebsite; }
            set { _SelectedWebsite = value; OnPropertyChanged(); }
        }
        
        private Enums.ComicType _SelectedType;
        public Enums.ComicType SelectedType
        {
            get { return _SelectedType; }
            set { _SelectedType = value; OnPropertyChanged(); }
        }

        private string _UrlText;
        public string UrlText
        {
            get { return _UrlText; }
            set { _UrlText = value; OnPropertyChanged(); }
        }

        private string _Path;
        public string Path
        {
            get { return _Path; }
            set { _Path = value; OnPropertyChanged(); }
        }

        private Visibility _DownloadingInputVisibility;
        public Visibility DownloadingInputVisibility
        {
            get { return _DownloadingInputVisibility; }
            set { _DownloadingInputVisibility = value; OnPropertyChanged(); }
        }
        #endregion
        #region DownloadingProcessProperties
        private float _DownloadingProgressComicsOfPagePercent;
        public float DownloadingProgressComicsOfPagePercent
        {
            get { return _DownloadingProgressComicsOfPagePercent; }
            set { _DownloadingProgressComicsOfPagePercent = value; OnPropertyChanged(); }
        }

        private float _DownloadingProgressComicPercent;
        public float DownloadingProgressComicPercent
        {
            get { return _DownloadingProgressComicPercent; }
            set { _DownloadingProgressComicPercent = value; OnPropertyChanged(); }
        }

        private string _DownloadingChapterName;
        public string DownloadingChapterName
        {
            get { return _DownloadingChapterName; }
            set { _DownloadingChapterName = value; OnPropertyChanged(); }
        }

        private string _DownloadingComicName;
        public string DownloadingComicName
        {
            get { return _DownloadingComicName; }
            set { _DownloadingComicName = value; OnPropertyChanged(); }
        }

        private Visibility _DownloadingProgressVisibility;
        public Visibility DownloadingProgressVisibility
        {
            get { return _DownloadingProgressVisibility; }
            set { _DownloadingProgressVisibility = value; OnPropertyChanged(); }
        }

        private Visibility _DownloadingProgressPageTotalVisibility;
        public Visibility DownloadingProgressPageTotalVisibility
        {
            get { return _DownloadingProgressPageTotalVisibility; }
            set { _DownloadingProgressPageTotalVisibility = value; OnPropertyChanged(); }
        }

        #endregion

        #region Variables
        private Task _DownloadingTask;
        public Task DownloadingTask
        {
            get { return _DownloadingTask; }
            set { _DownloadingTask = value;}
        }
        #endregion
        #region Commands
        public ICommand SelectorsEditorDisplayCommand { get; set; }
        public ICommand SelectorsAdderDisplayCommand { get; set; }
        public ICommand SelectedWebsiteCommand { get; set; }
        public ICommand TypeComboBoxLoadedCommand { get; set; }
        public ICommand WebsitesComboBoxLoadedCommand { get; set; }
        public ICommand DownloadCommand { get; set; }
        public ICommand CancelingDownloadingCommand { get; set; }
        public ICommand PathLoadedCommand { get; set; }
        #endregion
        public DownloaderViewModel()
        {
            IsEditSelectorsButtonEnable = false;
            DownloadingProgressVisibility = Visibility.Collapsed;
            DownloadingProgressPageTotalVisibility = Visibility.Collapsed;
            SelectorsEditorDisplayCommand = new RelayCommand<ComboBox>(p => true, SelectorsEditorDisplay);
            SelectorsAdderDisplayCommand = new RelayCommand<ComboBox>(p => true, SelectorsAdderDisplay);
            SelectedWebsiteCommand = new RelayCommand<object>(p => true, p => IsEditSelectorsButtonEnable = true);
            WebsitesComboBoxLoadedCommand = new RelayCommand<object>(p => true, LoadWebsites);
            TypeComboBoxLoadedCommand = new RelayCommand<ComboBox>
            (
                p => p is ComboBox ? true : false,
                p => p.ItemsSource = Enum.GetNames(typeof(Enums.ComicType))
            );
            DownloadCommand = new RelayCommand<object>(p => true, Download);
            CancelingDownloadingCommand = new RelayCommand<object>(p => true, CancelDownloading);
            PathLoadedCommand = new RelayCommand<TextBox>(p => p is TextBox ? true : false, p =>
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\" + "Downloads";
                DownloadHelper.CreateDirectory(path);
                p.Text = path;
            });

        }
        void CancelDownloading(object p)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            //DownloadingTask.Dispose();
            //DownloadingProgressCollapsed();
        }
        void DownloadingProgressDisplay()
        {
            DownloadingInputVisibility = Visibility.Collapsed;
            DownloadingProgressVisibility = Visibility.Visible;
        }
        void DownloadingProgressCollapsed()
        {
            DownloadingProgressVisibility = Visibility.Collapsed;
            DownloadingInputVisibility = Visibility.Visible;
        }
        void SelectorsEditorDisplay(ComboBox p)
        {
            int tempSeleted = p.SelectedIndex;
            (new SelectorsEditorWView(p.SelectedValue as WebsiteInformation)).ShowDialog();
            LoadWebsites();
            p.SelectedIndex = tempSeleted;
        }
        void SelectorsAdderDisplay(ComboBox p)
        {
            int tempSeleted = p.SelectedIndex;
            (new SelectorsAdderWView()).ShowDialog();
            LoadWebsites();
            p.SelectedIndex = tempSeleted;
        }
        void LoadWebsites(object p = null)
        {
            string filePath = Variables.DataFilePath;
            WebsiteInformation[] csses = JsonHelper.GetDeserializeJsonFromFile<WebsiteInformation[]>(filePath);
            if (csses.Length == 0) return;
            Websites = csses;
        }
        void BeforeDownloadingComic(string comicName, float onePercent, object o)
        {
            DownloadingComicName = comicName;
        }
        void BeforeDownloadingChapter(string chapterName, float onePercent, object isFirstDownloading)
        {
            DownloadingChapterName = "Downloading " + chapterName;
            if((bool)isFirstDownloading)
            {
                DownloadingProgressComicPercent += onePercent;
            }
        }
        void AfterDownloadedComic(string s, float onePercentComicOfPage, object o)
        {
            DownloadingProgressComicPercent = 0;
            DownloadingProgressComicsOfPagePercent += onePercentComicOfPage;
        }
        void AfterDownloadedComics(string s, float onePercent, object o)
        {
            DownloadingProgressComicsOfPagePercent = 0;
        }
        void Download(object p)
        {
            if (UrlText is null || UrlText == "" || Path == "" || SelectedWebsite is null || SelectedType == 0)
            {
                //alert
                MessageBox.Show("You must type all of the input");
            }
            Path = Path.Replace(@"/", @"\");
            WebsiteInformation selectors = SelectedWebsite;
            if (SelectedType == Enums.ComicType.Chapter)
            {
                DownloadingTask = Task.Run(() => 
                { 
                    Downloader.ChapterDownloader(UrlText, selectors, Path);
                });
            }
            else if (SelectedType == Enums.ComicType.Comic)
            {
                DownloadingTask = Task.Run(() =>
                {
                    DownloadingProgressDisplay();
                    Downloader.ComicDownloader(UrlText, selectors, Path,
                        BeforeDownloadingComic, BeforeDownloadingChapter);
                    DownloadingProgressCollapsed();
                });
            }
            else if (SelectedType == Enums.ComicType.Comics)
            {
                DownloadingTask = Task.Run(() =>
                {
                    DownloadingProgressPageTotalVisibility = Visibility.Visible;
                    DownloadingProgressDisplay();
                    Downloader.ComicsDownloader(UrlText, selectors, Path,
                        BeforeDownloadingComic, BeforeDownloadingChapter,
                        AfterDownloadedComics, AfterDownloadedComic);
                    DownloadingProgressCollapsed();
                    DownloadingProgressComicsOfPagePercent = 0;
                    DownloadingProgressComicPercent = 0;
                    DownloadingProgressPageTotalVisibility = Visibility.Collapsed;
                });
            }
        }
    }
}
