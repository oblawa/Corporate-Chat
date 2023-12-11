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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CorporateChat.ViewModel;

namespace CorporateChat
{
    /// <summary>
    /// Логика взаимодействия для AuthotizationWindow.xaml
    /// </summary>
    public partial class AuthotizationWindow : Window
    {
        //private SqlConnection sqlConnection = null;
        public AuthotizationWindow()
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


        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).password = ((PasswordBox)sender).Password;
            }
        }
    }
}
