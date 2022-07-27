using ComicDownloader.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class NotifyYesNoWViewModel : BaseViewModel
    {
        #region Commands
        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }
        #endregion
        #region Properties
        public bool IsYes { get; set; }
        public bool IsNo { get; set; }
        private string _DisplayText;

        public string DisplayText
        {
            get { return _DisplayText; }
            set { _DisplayText = value; }
        }

        #endregion
        public NotifyYesNoWViewModel(string text)
        {
            DisplayText = text;
            IsYes = false;
            IsNo = false;
            YesCommand = new RelayCommand<Window>(p => p is Window ? true : false, p => { CloseWindow(p); IsYes = true; });
            NoCommand = new RelayCommand<Window>(p => p is Window ? true : false, p => { CloseWindow(p); IsNo = true; });
        }
        void CloseWindow(Window p)
        {
            Window.GetWindow(p).Close();
        }
    }
}
