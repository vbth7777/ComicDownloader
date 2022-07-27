using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ComicDownloader.Core;

namespace MVVM.ViewModel
{
    public class NotifyOKWViewModel : BaseViewModel
    {
        #region Commands
        public ICommand OKCommand { get; set; }
        #endregion
        #region Properties
        private string _DisplayText;

        public string DisplayText
        {
            get { return _DisplayText; }
            set { _DisplayText = value; }
        }

        #endregion
        public NotifyOKWViewModel(string text)
        {
            DisplayText = text;
            OKCommand = new RelayCommand<Window>(p => p is Window ? true : false, p => Window.GetWindow(p).Close());
        }
    }
}
