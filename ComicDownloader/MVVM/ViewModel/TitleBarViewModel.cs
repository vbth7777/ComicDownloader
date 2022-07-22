using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ComicDownloader.Core;
using ComicDownloader.MVVM.View;

namespace ComicDownloader.MVVM.ViewModel
{
    public class TitleBarViewModel : BaseViewModel
    {
        private Window win;
        #region Commands
        public ICommand CloseCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand MouseDownCommand { get; set; }
        #endregion
        public TitleBarViewModel()
        {
            LoadCommands();
        }
        void LoadCommands()
        {
            CloseCommand = new RelayCommand<UserControl>(p => p is UserControl ? true : false, CloseWindow);
            MinimizeCommand = new RelayCommand<UserControl>(p => p is UserControl ? true : false, MinimizeWindow);
            MaximizeCommand = new RelayCommand<UserControl>(p => p is UserControl ? true : false, MaximizeWindow);
            MouseDownCommand = new RelayCommand<UserControl>(p => p is UserControl ? true : false, DragWindow);
        }
        void CloseWindow(UserControl p)
        {
            if (win is null)
                win = Window.GetWindow(p);
            win.Close();
        }
        void MinimizeWindow(UserControl p)
        {
            if (win is null)
                win = Window.GetWindow(p);
            win.WindowState = WindowState.Minimized;
        }
        void MaximizeWindow(UserControl p)
        {
            if (win is null)
                win = Window.GetWindow(p);
            if(win.WindowState == WindowState.Maximized)
            {
                win.WindowState = WindowState.Normal;
            }
            else
            {
                win.WindowState = WindowState.Maximized;
            }
        }
        void DragWindow(UserControl p)
        {
            if (win is null)
                win = Window.GetWindow(p);
            win.DragMove();
        }
    }
}
