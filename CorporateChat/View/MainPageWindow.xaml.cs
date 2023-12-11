using CorporateChat.ViewModel;
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

namespace CorporateChat.View
{
    /// <summary>
    /// Логика взаимодействия для MainPageWindow.xaml
    /// </summary>
    public partial class MainPageWindow : Window
    {
        public MainPageWindow()
        {
            InitializeComponent();
            //DataContext = new MainViewModel();
            buttonMinimize.Click += buttonMinimize_Click;
            buttonExit.Click += buttonExit_Click;
            //buttonSend.Click += buttonSend_Click;
        }
        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
        //private void buttonSend_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.MainWindow.WindowState = WindowState.Minimized;
        //}
    }
}
