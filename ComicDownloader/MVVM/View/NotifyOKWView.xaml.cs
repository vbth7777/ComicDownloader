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
using MVVM.ViewModel;

namespace MVVM.View
{
    /// <summary>
    /// Interaction logic for NotifyOKWView.xaml
    /// </summary>
    public partial class NotifyOKWView : Window
    {
        public NotifyOKWView(string text)
        {
            InitializeComponent();
            DataContext = new NotifyOKWViewModel(text);
        }
    }
}
