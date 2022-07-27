using ComicDownloader.Core;
using ComicDownloader.Helper;
using MVVM.ViewModel;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComicDownloader.MVVM.ViewModel
{
    internal class SelectorsEditorWViewModel : SelectorsAdderAndEditor
    {
        public SelectorsEditorWViewModel()
        {
            ConfirmCommand = new RelayCommand<Button>(p => true, EditSelectors);
        }
        public SelectorsEditorWViewModel(WebsiteInformation css)
        {
            Website = css.Url;
            NextPageButtonSelector = css.Comics.NextPageButtonSelector;
            ComicUrlsSelector = css.Comics.ComicUrlsSelector;
            ComicNameSelector = css.Comic.ComicNameSelector;
            ComicChaptersSelector = css.Comic.ComicChaptersSelector;
            ChapterImagesSelector = css.Chapter.ChapterImagesSelector;

            ConfirmCommand = new RelayCommand<Button>(p => true, EditSelectors);
        }
        void EditSelectors(Button p)
        {
            string filePath = Variables.DataFilePath;
            WebsiteInformation[] csses = JsonHelper.GetDeserializeJsonFromFile<WebsiteInformation[]>(filePath);
            int length = csses.Length;
            for(int i = 0; i < length; i++)
            {
                if(csses[i].Url != Website)
                {
                    continue;
                }
                csses[i].Comics.NextPageButtonSelector = NextPageButtonSelector;
                csses[i].Comics.ComicUrlsSelector = ComicUrlsSelector;
                csses[i].Comic.ComicNameSelector = ComicNameSelector;
                csses[i].Comic.ComicChaptersSelector = ComicChaptersSelector;
                csses[i].Chapter.ChapterImagesSelector = ChapterImagesSelector;
            }
            JsonHelper.SerializeAndSaveJson(csses, filePath);
            Window.GetWindow(p).Close();
        }
    }
}
