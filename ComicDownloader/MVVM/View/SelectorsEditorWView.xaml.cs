using ComicDownloader.Core;
using ComicDownloader.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ComicDownloader.MVVM.View
{
    /// <summary>
    /// Interaction logic for SelectorsEditorWView.xaml
    /// </summary>
    public partial class SelectorsEditorWView : Window
    {
        public SelectorsEditorWView(WebsiteInformation css = null)
        {
            InitializeComponent();
            if (css is null)
            {
                this.DataContext = new SelectorsEditorWViewModel();
            }
            else
            {
                this.DataContext = new SelectorsEditorWViewModel(css);
            }
        }
    }
}
