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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CorporateChat.ViewModel;
using DevExpress.Mvvm.POCO;

namespace CorporateChat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        //private SqlConnection sqlConnection = null;
        public RegistrationWindow()
        {
            InitializeComponent();
            buttonMinimize.Click += buttonMinimize_Click;
            buttonExit.Click += buttonExit_Click;         
        }


        //private void buttonRegister_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(loginTb.Text);
        //    SqlCommand command = new SqlCommand("INSERT INTO [Users] (Login, Password) VALUES (@Login, @Password)", sqlConnection);
        //    command.Parameters.AddWithValue("Login", loginTb.Text);
        //    command.Parameters.AddWithValue("Password", passwordTb.Password);
        //    MessageBox.Show(command.ExecuteNonQuery().ToString());
        //}

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
