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
    /// Логика взаимодействия для SecondAuthWindow.xaml
    /// </summary>
    public partial class SecondAuthWindow : Window
    {
        public SecondAuthWindow()
        {
            InitializeComponent();
            buttonMinimize.Click += buttonMinimize_Click;
            buttonExit.Click += buttonExit_Click;
        }

        // события клика
        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
