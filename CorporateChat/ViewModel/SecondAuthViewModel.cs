using CorporateChat.Core;
using CorporateChat.Model;
using CorporateChat.Network;
using CorporateChat.View;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CorporateChat.ViewModel
{
    class SecondAuthViewModel : ViewModelBase
    {
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public string UserMail { get; set; }
        private Server server { get; set; }
        public string OTP { get; set; }
        public RelayCommand SendOtpCommand { get; set; }
        
        public SecondAuthViewModel(Server _server,string name, Guid id, string mail) 
        {
            try
            {
                server = _server;
                UserName = name;
                UserId = id;
                UserMail = mail;
                SendOtpCommand = new RelayCommand(o => SendOtp());

                server.secAuthCompletedEvent += SecondAuthCompleted;
                server.secAuthErrorEvent += SecondAuthError;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания 2fa {ex.Message}");
            }
        }
        //public SecondAuthViewModel()
        //{
        //    try
        //    {
        //        SendOtpCommand = new RelayCommand(o => SendOtp());

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void SecondAuthError()
        {
            MessageBox.Show("Неправильный код");
        }

        private void SecondAuthCompleted()
        {
            var sessionId = server.packetReader.ReadMessage();
            var name = server.packetReader.ReadMessage();
            var surname = server.packetReader.ReadMessage();
            var post = server.packetReader.ReadMessage();
            User newUser = new User(UserId, UserName, UserMail, name, surname, post);
            var mainVM = new MainViewModel(server, newUser, Guid.Parse(sessionId));
            Application.Current.Dispatcher.Invoke(() =>
            {
                //mainVM.LoadOnlineUsersCommand.Execute(null);
                MainPageWindow mainPage = new MainPageWindow { DataContext = mainVM };
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = mainPage;
                mainPage.Show();
            });
        }

        private void SendOtp()
        {
            server.SendOtpToServer(OTP);
        }
    }
}
