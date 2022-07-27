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
using MVVM.ViewModel;
using System.Windows.Shapes;

namespace MVVM.View
{
    /// <summary>
    /// Interaction logic for NotifyYesNoWView.xaml
    /// </summary>
    public partial class NotifyYesNoWView : Window
    {
        public NotifyYesNoWView(string text)
        {
            InitializeComponent();
            DataContext = new NotifyYesNoWViewModel(text);
        }
    }
}
