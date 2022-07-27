using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ComicDownloader.Core;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Web.WebView2.Core;
using System.Windows;
using System.Windows.Controls;
using ComicDownloader.Core;
using MVVM.View;
using MVVM.ViewModel;
using System.Text.RegularExpressions;

namespace ComicDownloader.MVVM.ViewModel
{
    public class SelectorsGetterWViewModel : BaseViewModel
    {
        private string ScriptAddClickEvent =
            @"
var ComicDownloader_AElementsSelector = null;
var ComicDownloader_AElementSelector = null;
var ComicDownloader_HOrPElementSelector = null;
var ComicDownloader_IMGElementsSelector = null;
var originalTitle = document.title;
var isClicked = false;
var isHighlightAll = true;
$('*').click(function(e) {
  e.preventDefault();
});
function generateQuerySelectors (el) {
  if (el.tagName.toLowerCase() == 'html')
      return 'HTML';
  var str = el.tagName;
  if (el.className) {
      var classes = el.className.split(/\s/);
  }
  return generateQuerySelectors(el.parentNode) + ' > ' + str;
}
function generateQuerySelector(elm) {
    if (elm.tagName === 'BODY') return 'BODY';
    const names = [];
    while (elm.parentElement && elm.tagName !== 'BODY') {
	let c = 1, e = elm;
	for (; e.previousElementSibling; e = e.previousElementSibling, c++) ;
	names.unshift(elm.tagName + ':nth-child(' + c + ')');
	elm = elm.parentElement;
    }
    return names.join(' > ');
}
function changeTitle()
{
    document.title += ' Clicked';
    isClicked = true;
}
function onClick(p)
{
    const paths = p.path;
    for(let e of paths)
    {
	try{
	    if(e.tagName == 'A')
	    {
		const elementsSelector = generateQuerySelectors(e);
		const elementSelector = generateQuerySelector(e);
		const elements = Array.from(document.querySelectorAll(elementsSelector));
		const element = document.querySelector(elementSelector);
		ComicDownloader_AElementsSelector = elementsSelector;
		ComicDownloader_AElementSelector = elementSelector;
		console.log(elements);
		console.log(element);
		if(isHighlightAll)
		    elements.map(p => p.setAttribute('style', 'background: red;'))
		element.setAttribute('style', 'background: red;')
		if(!isClicked)
		    changeTitle();
	    }
	    else if(e.tagName == 'IMG')
	    {
		const elementsSelector = generateQuerySelectors(e);
		const elements = Array.from(document.querySelectorAll(elementsSelector));
		ComicDownloader_IMGElementsSelector = elementsSelector;
		console.log(elements);
		elements.map(p => p.setAttribute('style', 'background: red;'))
		if(!isClicked)
		    changeTitle();
	    }
	    else if(e.tagName.match(/^H\d+|^P/g))
	    {
		const elementSelector = generateQuerySelector(e);
		const element = document.querySelector(elementSelector);
		ComicDownloader_HOrPElementSelector = elementSelector;
		console.log(element);
		element.setAttribute('style', 'background: red;')
		if(!isClicked)
		    changeTitle();
	    }
	}
	catch(error){}
    }
    isClicked = false;
}
document.addEventListener('click', onClick);
";
        private string ScriptRemoveClickEvent = @" document.removeEventListener('click', onClick);";
        private string ScriptHelpWebViewCanNavigation =  @"$('*').off()";
        private Enums.ComicType SelectorsSetterMode;
        public bool IsDOMContentLoaded = false;
        private bool canClicked = false;
        #region Properties
        private string _WebViewSource;
        public string WebViewSource
        {
            get { return _WebViewSource; }
            set { _WebViewSource = value; OnPropertyChanged(); }
        }

        public WebsiteInformation Selectors { get; set; }
        #endregion
        #region Commands
        public ICommand CoreWebView2InitializationCompletedCommmand { get; set; }
        public ICommand SetComicsSelectorsCommand { get; set; }
        public ICommand SetComicSelectorsCommand { get; set; }
        public ICommand SetChapterSelectorsCommand { get; set; }
        public ICommand ConfirmSelectorsCommand { get; set; }
        #endregion
        public SelectorsGetterWViewModel(string url)
        {
            WebViewSource = url;
            Selectors = new WebsiteInformation();
            LoadCommands();
        }
        void LoadCommands()
        {
            ConfirmSelectorsCommand = new RelayCommand<Window>(p => p is Window ? true : false, async p =>
            {
                p.Close();
            });
            SetComicsSelectorsCommand = new RelayCommand<WebView2>(p => p is WebView2 ? true : false, async p =>
            {
                if(!(Selectors.Comics.ComicUrlsSelector is null) && !(Selectors.Comics.NextPageButtonSelector is null))
                {
                    //alert
                    MessageBox.Show("You had full chapter selectors");
                    return;
                }
                GetterChecker();
                SelectorsSetterMode = Enums.ComicType.Comics;
                EnterToGetterMode(p.CoreWebView2);
                await p.CoreWebView2.ExecuteScriptAsync("isHighlightAll = false");
                MessageOkDisplay("Please click to next page button");
            });
            SetComicSelectorsCommand = new RelayCommand<WebView2>(p => p is WebView2 ? true : false, async p =>
            {
                if(!(Selectors.Comic.ComicChaptersSelector is null) && !(Selectors.Comic.ComicNameSelector is null))
                {
                    //alert
                    MessageBox.Show("You had full comic selectors");
                    return;
                }
                GetterChecker();
                SelectorsSetterMode = Enums.ComicType.Comic;
                EnterToGetterMode(p.CoreWebView2);
                await p.CoreWebView2.ExecuteScriptAsync("isHighlightAll = false");
                MessageOkDisplay("Please click to comic name");
            });
            SetChapterSelectorsCommand = new RelayCommand<WebView2>(p => p is WebView2 ? true : false, p =>
            {
                if(!(Selectors.Chapter.ChapterImagesSelector is null))
                {
                    //alert
                    MessageBox.Show("You had full comics selectors");
                    return;
                }
                GetterChecker();
                SelectorsSetterMode = Enums.ComicType.Chapter;
                EnterToGetterMode(p.CoreWebView2);
                MessageOkDisplay("Please click to images chapter");
            });
            CoreWebView2InitializationCompletedCommmand = new RelayCommand<WebView2>(p => p is WebView2 ? true : false, async p =>
            {
                WebView2 webView = p;
                await webView.EnsureCoreWebView2Async();
                CoreWebView2 coreWebView = webView.CoreWebView2;
                coreWebView.DOMContentLoaded += DOMContentLoaded;
                //coreWebView.NavigationStarting += NavigationStarting;
                coreWebView.DocumentTitleChanged += Clicked;
            });
        }

        //private void NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        //{
        //    canClicked = false;
        //}

        void GetterChecker()
        {
            if (!IsDOMContentLoaded)
            {
                //alert
                MessageBox.Show("Please wait for dom content loaded");
                return;
            }
            else if(SelectorsSetterMode != 0)
            {
                //alert
                MessageBox.Show("You must done to set selectors");
                return;
            }

        }
        async void EnterToGetterMode(CoreWebView2 p)
        {
            await p.ExecuteScriptAsync(ScriptAddClickEvent);
        }
        async void ExitToGetterMode(CoreWebView2 p, bool CanNavigation = false)
        {
            await p.ExecuteScriptAsync(ScriptRemoveClickEvent + "; "+ @"
try{Array.from(document.querySelectorAll(ComicDownloader_AElementsSelector)).forEach(p => p.setAttribute('style', ''))}catch(error){}
try{document.querySelector(ComicDownloader_AElementSelector).setAttribute('style', '')}catch(error){}
try{document.querySelector(ComicDownloader_HOrPElementSelector).setAttribute('style', '')}catch(error){}
try{Array.from(document.querySelector(ComicDownloader_IMGElementsSelector)).forEach(p => p.setAttribute('style', ''))}catch(error){}
");
            if (CanNavigation)
                await p.ExecuteScriptAsync(ScriptHelpWebViewCanNavigation);
        }
        void MessageOkDisplay(string text)
        {
            (new NotifyOKWView(text)).ShowDialog();
        }
        void NoClicked(CoreWebView2 coreWebView)
        {
            ExitToGetterMode(coreWebView);
            (new NotifyOKWView("Please click again!")).ShowDialog();
            EnterToGetterMode(coreWebView);
        }
        NotifyYesNoWViewModel NotifyYesNoDisplay(string displayText)
        {
            NotifyYesNoWView notify = new NotifyYesNoWView(displayText);
            notify.ShowDialog();
            return notify.DataContext as NotifyYesNoWViewModel;
        }
        void ReEnterToGetterMode(CoreWebView2 p)
        {
            ExitToGetterMode(p);
            EnterToGetterMode(p);
        }
        private async void Clicked(object? sender, object e)
        {
            if (sender is null || !canClicked || SelectorsSetterMode == 0) return;
            CoreWebView2 coreWebView = sender as CoreWebView2;
            if (SelectorsSetterMode == Enums.ComicType.Comics)
            {
                if(Selectors.Comics.NextPageButtonSelector is null)
                {
                    NotifyYesNoWViewModel vm = NotifyYesNoDisplay("Are you sure about next page selector? (it must be a tag)");
                    if(!vm.IsYes)
                    {
                        NoClicked(coreWebView);
                    }
                    else
                    {
                        string selector = await coreWebView.ExecuteScriptAsync("ComicDownloader_AElementSelector");
                        Selectors.Comics.NextPageButtonSelector = Regex.Replace(selector, "^\"|\"$", "");
                        await coreWebView.ExecuteScriptAsync("isHighlightAll = true");
                        ReEnterToGetterMode(coreWebView);
                        MessageOkDisplay("Please click to comic urls");
                    }
                }    
                else if(Selectors.Comics.ComicUrlsSelector is null)
                {
                    NotifyYesNoWViewModel vm = NotifyYesNoDisplay("Are you sure about comic urls selector? (it must be a tags)");
                    if(!vm.IsYes)
                    {
                        NoClicked(coreWebView);
                    }
                    else
                    {
                        string selector = await coreWebView.ExecuteScriptAsync("ComicDownloader_AElementsSelector");
                        Selectors.Comics.ComicUrlsSelector = Regex.Replace(selector, "^\"|\"$", "");
                        SelectorsSetterMode = 0;
                        MessageOkDisplay("Success adding comics selectors");
                        ExitToGetterMode(coreWebView, true);
                    }
                }
            }
            else if(SelectorsSetterMode == Enums.ComicType.Comic)
            {
                if(Selectors.Comic.ComicNameSelector is null)
                {
                    NotifyYesNoWViewModel vm = NotifyYesNoDisplay("Are you sure about comic name selector? (it must be h1,h2,... tag)");
                    if(!vm.IsYes)
                    {
                        NoClicked(coreWebView);
                    }
                    else
                    {
                        string selector = await coreWebView.ExecuteScriptAsync("ComicDownloader_HOrPElementSelector");
                        Selectors.Comic.ComicNameSelector = Regex.Replace(selector, "^\"|\"$", "");
                        await coreWebView.ExecuteScriptAsync("isHighlightAll = true");
                        ReEnterToGetterMode(coreWebView);
                        MessageOkDisplay("Please click to comic chapters");
                    }
                }    
                else if(Selectors.Comic.ComicChaptersSelector is null)
                {
                    NotifyYesNoWViewModel vm = NotifyYesNoDisplay("Are you sure about comic chapters selector? (it must be a tags)");
                    if(!vm.IsYes)
                    {
                        NoClicked(coreWebView);
                    }
                    else
                    {
                        string selector = await coreWebView.ExecuteScriptAsync("ComicDownloader_AElementsSelector");
                        Selectors.Comic.ComicChaptersSelector = Regex.Replace(selector, "^\"|\"$", "");
                        SelectorsSetterMode = 0;
                        MessageOkDisplay("Success adding comic selectors");
                        ExitToGetterMode(coreWebView, true);
                    }
                }
            }
            else if(SelectorsSetterMode == Enums.ComicType.Chapter)
            {
                if(Selectors.Chapter.ChapterImagesSelector is null)
                {
                    NotifyYesNoWViewModel vm = NotifyYesNoDisplay("Are you sure about chapter images selector? (it must be img tags)");
                    if(!vm.IsYes)
                    {
                        NoClicked(coreWebView);
                    }
                    else
                    {
                        string selector = await coreWebView.ExecuteScriptAsync("ComicDownloader_IMGElementsSelector");
                        Selectors.Chapter.ChapterImagesSelector = Regex.Replace(selector, "^\"|\"$", "");
                        SelectorsSetterMode = 0;
                        MessageOkDisplay("Success adding chapter selector");
                        ExitToGetterMode(coreWebView, true);
                    }

                }    
            }
        }

        private async void DOMContentLoaded(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if (sender is null) return;
            IsDOMContentLoaded = true;
            canClicked = true;
        }
    }
}
