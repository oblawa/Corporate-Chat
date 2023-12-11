using CorporateChat.Core;
using CorporateChat.Model;
using CorporateChat.Network;
using CorporateChat.View;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CorporateChat.ViewModel
{
    class RegViewModel: ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; }
        public RelayCommand ConnectToServerCommand { get; set; }
        public RelayCommand SendRegistrationDataCommand { get; set; }
        public RelayCommand OpenAuthWindowCommand { get; set; }
        private Server _server;
        public string username { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string post { get; set; }
        public RegViewModel()
        {
            Users = new ObservableCollection<User>();
            _server = new Server();
            ConnectToServerCommand = new RelayCommand(o => Connect());
            SendRegistrationDataCommand = new RelayCommand(o => SendRegistrationData(), o => !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(mail));
            _server.registrationFailedEvent += ShowException;
            _server.registrationCompletedEvent += RegistrationComplited;
            OpenAuthWindowCommand = new RelayCommand(o => OpenAuthWindow());
        }
        public RegViewModel(Server server)
        {
            Users = new ObservableCollection<User>();
            _server = server;
            SendRegistrationDataCommand = new RelayCommand(o => SendRegistrationData(), o => !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password));
            _server.registrationFailedEvent += ShowException;
            _server.registrationCompletedEvent += RegistrationComplited;
            OpenAuthWindowCommand = new RelayCommand(o => OpenAuthWindow());
        }

        private void OpenAuthWindow()
        {
            //var authVM = new AuthViewModel(_server);
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    AuthotizationWindow authotizationWindow = new AuthotizationWindow() { DataContext = authVM };
            //    authotizationWindow.Closed += (s, e) => Application.Current.MainWindow.Close(); // Закрыть основное окно при закрытии окна авторизации
            //    Application.Current.MainWindow.Hide(); // Скрыть основное окно
            //    Application.Current.MainWindow = authotizationWindow;
            //    authotizationWindow.Show();
            //});




            //var authVM = new AuthViewModel(_server);
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    AuthotizationWindow authotizationWindow = new AuthotizationWindow() { DataContext = authVM };
            //    Application.Current.MainWindow.Close();
            //    Application.Current.MainWindow = authotizationWindow;
            //    authotizationWindow.Show();
            //});



            //var authVM = new AuthViewModel(_server);
            //AuthotizationWindow authotizationWindow = new AuthotizationWindow() { DataContext = authVM };
            //Application.Current.MainWindow.Close();
            //Application.Current.MainWindow = authotizationWindow;
            //authotizationWindow.Show();
        }

        private void RegistrationComplited()
        {
            //var id = Guid.Parse(_server.packetReader.ReadMessage());
            //var username = _server.packetReader.ReadMessage();
            //var mail = _server.packetReader.ReadMessage();
            //var name = _server.packetReader.ReadMessage();
            //var surname = _server.packetReader.ReadMessage();
            //var post = _server.packetReader.ReadMessage();
            //User newUser = new User(id, username , mail, name, surname, post);
            //var mainVM = new MainViewModel(_server, newUser);
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    //mainVM.LoadOnlineUsersCommand.Execute(null);
            //    MainPageWindow mainPage = new MainPageWindow { DataContext = mainVM };
            //    Application.Current.MainWindow.Close();
            //    Application.Current.MainWindow = mainPage;
            //    mainPage.Show();          
            //});
        }


        private void ShowException()
        {
            var exceptionText = _server.packetReader.ReadMessage();
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(exceptionText);            
            });
        }

        private void Connect()
        {
            //MessageBox.Show("Подключен к серверу");
            _server.ConnectToServer();
        }
        private void SendRegistrationData()
        {
            _server.SendRegidtrationDataToServer(username, password, mail, name, surname, post);
        }
    }
}
