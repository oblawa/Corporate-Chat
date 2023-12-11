using CorporateChat.Core;
using CorporateChat.Network;
using CorporateChat.View;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace CorporateChat.ViewModel
{
    class AuthViewModel : ViewModelBase
    {
        private Server server;
        public string username { get; set; }
        public string password { get; set; }
        public RelayCommand OpenRegWindowCommand { get; set; }
        public RelayCommand SendAuthDataCommand { get; set; }
        public RelayCommand ConnectToServerCommand { get; set; }
        public AuthViewModel() 
        {
            server = new Server();
            ConnectToServerCommand = new RelayCommand(o => Connect());
            OpenRegWindowCommand = new RelayCommand(o => OpenRegWindow());
            SendAuthDataCommand = new RelayCommand(o => SendAuthData());
            server.authCompletedEvent += AuthCompleted;
            server.authFailedEvent += AuthFailed;
        }

        private void AuthFailed()
        {
            var exceptionText = server.packetReader.ReadMessage();
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(exceptionText);
            });
        }

        private void AuthCompleted()
        {
            try
            {
                var id = server.packetReader.ReadMessage();
                var username = server.packetReader.ReadMessage();
                var mail = server.packetReader.ReadMessage();

                //var secAuthVM = new SecondAuthViewModel(server, username, id, mail);
                //Application.Current.Dispatcher.Invoke(() =>
                //{
                //    SecondAuthWindow secAuthPage = new SecondAuthWindow { DataContext = secAuthVM };
                //    secAuthPage.Closed += (s, e) => Application.Current.MainWindow.Close(); // Закрыть основное окно при закрытии нового окна
                //    Application.Current.MainWindow.Hide(); // Скрыть основное окно
                //    Application.Current.MainWindow = secAuthPage;
                //    secAuthPage.Show();
                //});

                var secAuthVM = new SecondAuthViewModel(server, username, Guid.Parse(id), mail);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    //mainVM.LoadOnlineUsersCommand.Execute(null);
                    SecondAuthWindow secAuthPage = new SecondAuthWindow { DataContext = secAuthVM };
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = secAuthPage;
                    secAuthPage.Show();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //var id = Guid.Parse(server.packetReader.ReadMessage());
            //var username = server.packetReader.ReadMessage();
            //var mail = server.packetReader.ReadMessage();
            ////var mainVM = new MainViewModel(server, username, id);
            //var secAuthVM = new SecondAuthViewModel(server, username, id, mail);
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    //mainVM.LoadOnlineUsersCommand.Execute(null);
            //    SecondAuthWindow secAuthPage = new SecondAuthWindow { DataContext = secAuthVM };
            //    Application.Current.MainWindow.Close();
            //    Application.Current.MainWindow = secAuthPage;
            //    secAuthPage.Show();
            //});
        }

        private void SendAuthData()
        {
            server.SendAuthDataToServer(username, password);
        }

        //public AuthViewModel()
        //{
        //    server = new Server();
        //    OpenRegWindowCommand = new RelayCommand(o => OpenRegWindow());
        //}
        private void OpenRegWindow()
        {
            var regVM = new RegViewModel(server);
            RegistrationWindow regWindow = new RegistrationWindow() { DataContext = regVM };
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = regWindow;
            regWindow.Show();
        }
        private void Connect()
        {
            //MessageBox.Show("Подключен к серверу");
            server.ConnectToServer();
        }
    }
}
