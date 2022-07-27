using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ComicDownloader.MVVM.ViewModel;

namespace ComicDownloader.MVVM.View
{
    /// <summary>
    /// Interaction logic for SelectorsGetterWView.xaml
    /// </summary>
    public partial class SelectorsGetterWView : Window
    {
        public SelectorsGetterWView(string url)
        {
            InitializeComponent();
            DataContext = new SelectorsGetterWViewModel(url);
        }
    }
}
