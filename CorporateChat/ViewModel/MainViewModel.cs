using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateChat.Model;
using CorporateChat.Network;
using CorporateChat.Core;
using System.Windows;
using CorporateChat.View;
using System.Collections;
using CorporateChat.View.Scripts;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace CorporateChat.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public string message { get; set; }
        public List<User> AllUsers { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Message> ChatMessages { get; set; }
        //private ObservableCollection<Message> _chatMessages;

        //public ObservableCollection<Message> ChatMessages
        //{
        //    get { return _chatMessages; }
        //    set
        //    {
        //        _chatMessages = value;
        //        RaisePropertyChanged(nameof(ChatMessages));
        //    }
        //}
        public ObservableCollection<Chat> Chats { get; set; }
        public RelayCommand SendMessageCommand { get; set; }
        public RelayCommand SendDestroingMessageCommand { get; set; }
        public bool IsTrue { get; set; }
        // новый чат
        public RelayCommand NewChatCommand { get; set; }
        public RelayCommand SelectionChangedCommand { get; set; }
        public IList selectedItems { get; set; }
        public ObservableCollection<User> NewChat_SelectedUsers { get; private set; }
        public string chatName { get; set; }
        //
        public ObservableCollection<ChatRadioButton> RadioButtons { get; set; }        
        public RelayCommand CreateNewChatCommand { get; set; }
        // просмотреть чат
        public RelayCommand ShowChatInfoCommand { get; set; }
        public RelayCommand AddNewUsersToChatCommand { get; set; }
        public RelayCommand DeleteUsersFromChatCommand { get; set; }
        public RelayCommand DeleteChatCommand { get; set; }
        public RelayCommand EditChatCommand { get; set; }
        public RelayCommand chatInfoSelectionChangedCommand { get; set; }
        public ObservableCollection<User> chatInfo_SelectedUsers { get; private set; }
        public IList chatInfoSelectedItems { get; set; }
        public ObservableCollection<User> usersNotInChat { get; set; }
        public RelayCommand usersToAddSelectionChangedCommand { get; set; }
        public ObservableCollection<User> usersToAdd_SelectedUsers { get; private set; }
        public RelayCommand AddUsersToChatCommand { get; set; }
        public IList usersToAddSelectedItems { get; set; }

        public ICommand ShowChatCommand { get; private set; }
        // глобальные переменные
        public string Username { get; set; }
        public Guid UID { get; set; }
        public string UserMail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Post { get; set; }
        private Server server;
        public Chat currentChat { get; set; }
        //private DispatcherTimer _timer;
        public int destroyTime { get; set; }
        public Guid sessionId { get; set; }

        public RelayCommand ShowProfileCommand { get; set; }
        public MainViewModel(Server _server, User _user, Guid _sessionId)
        {
            Username = _user.Username;
            UID = _user.UID;
            UserMail = _user.Mail;
            Name = _user.Name;
            Surname = _user.Surname;
            Post = _user.Post;
            IsTrue = true;
            // передаем экземпляр подключения к серверу
            server = _server;
            server.sessionId = _sessionId;
            // события
            server.messageRecievedEvent += MessageRecieved;
            server.destMessageRecievedEvent += DestroyingMessageRecieved;
            server.userDisconnectedEvent += UserDisconnected;
            
            Users = new ObservableCollection<User>();
            AllUsers = new List<User>();
            ChatMessages = new ObservableCollection<Message>();
            Chats = new ObservableCollection<Chat>();
            // отпавляем сообщения
            SendMessageCommand = new RelayCommand(o => SendMessage(UID, Name, Surname, message, currentChat.Id), o => !string.IsNullOrEmpty(message));
            destroyTime = 1;
            SendDestroingMessageCommand = new RelayCommand(o => SendDestroingMessage(UID, Name, Surname, message, currentChat.Id, DateTime.Now.AddMinutes(2)), o => !string.IsNullOrEmpty(message));
            // новый чат
            NewChatCommand = new RelayCommand(o => OpenNewChatDialog());
            SelectionChangedCommand = new RelayCommand(o => OnSelectionChanged());
            NewChat_SelectedUsers = new ObservableCollection<User>();
            CreateNewChatCommand = new RelayCommand(o => CreateNewChat(chatName, NewChat_SelectedUsers));
            ShowChatInfoCommand = new RelayCommand(o => ShowChatInfo());
            RadioButtons = new ObservableCollection<ChatRadioButton>();
            ShowChatCommand = new ToggleCommand<Guid>(ShowChat);
            // показать профиль
            ShowProfileCommand = new RelayCommand(o => ShowProfile());
            // принимаем чаты
            _server.newChatCreatedEvent += ShowNewChat;
            _server.chatsRecievedEvent += ShowChats;
            _server.userListRecievedEvent += LoadAllUsers;
            _server.connectedEvent += UserConnected;
            _server.deleteChatEvent += DeleteChatById;
            _server.newChatNameRecieved += ChangeChatName;
            // информация о чате
            AddNewUsersToChatCommand = new RelayCommand(o => AddNewUsersToChat());
            DeleteUsersFromChatCommand = new RelayCommand(o => DeleteUsersFromChat(chatInfo_SelectedUsers));
            DeleteChatCommand = new RelayCommand(o => DeleteChat());
            EditChatCommand = new RelayCommand(o => EditChat());
            chatInfo_SelectedUsers = new ObservableCollection<User>();
            chatInfoSelectionChangedCommand = new RelayCommand(o => chatInfoSelectionChanged());
            AddUsersToChatCommand = new RelayCommand(o => AddUsersToChat(usersToAdd_SelectedUsers));

            // новые пользователи
            usersNotInChat = new ObservableCollection<User>();
            usersToAdd_SelectedUsers = new ObservableCollection<User>();
            usersToAddSelectionChangedCommand = new RelayCommand(o => userToAddSelectionChanged());
            // удаляем самоуничтожающиеся сообщения
            _ = CheckForExpiredMessagesAsync();
        }

        private void ChangeChatName()
        {
            var chatId = server.packetReader.ReadMessage();
            var chatName = server.packetReader.ReadMessage();
            if (Chats.FirstOrDefault(chat => chat.Id == Guid.Parse(chatId)) != null)
            {
                Chats.FirstOrDefault(chat => chat.Id == Guid.Parse(chatId)).Name = chatName;
            }
        }

        private void DeleteChatById()
        {
            var chatId = Guid.Parse(server.packetReader.ReadMessage());
            Chat chatToDelete = Chats.FirstOrDefault(chat => chat.Id == chatId);
            if (chatToDelete != null)
            {
                Chats.Remove(chatToDelete);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ChatRadioButton radioButtonToDelete = RadioButtons.FirstOrDefault(rb => ((Guid)rb.CommandParameter) == chatId);
                    if (radioButtonToDelete != null)
                    {
                        RadioButtons.Remove(radioButtonToDelete);
                    }
                });
            }
        }

        private void AddUsersToChat(ObservableCollection<User> users)
        {
            server.AddUsersToChat(currentChat.Id, users);
            var usersList = users.ToList();
            foreach (User user in usersList)
            {
                currentChat.Interlocutors.Add(user);
                //Chats.FirstOrDefault(chat => chat.Id == currentChat.Id).Interlocutors.Add(user);
            }
        }

        private void userToAddSelectionChanged()
        {
            usersToAdd_SelectedUsers.Clear();
            foreach (User user in usersToAddSelectedItems)
            {
                usersToAdd_SelectedUsers.Add(user);
            }
        }

        private void chatInfoSelectionChanged()
        {
            chatInfo_SelectedUsers.Clear();
            foreach (User user in chatInfoSelectedItems)
            {
                chatInfo_SelectedUsers.Add(user);
            }
        }

        private void DeleteChat()
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                server.DeleteChat(currentChat.Id);                
            }
        }

        private void EditChat()
        {
            server.ChangeChatName(currentChat.Name, currentChat.Id);
        }

        private void DeleteUsersFromChat(ObservableCollection<User> users)
        {
            server.DeleteUsersFromChat(currentChat.Id, users);
            var usersList = users.ToList();
            foreach (User user in usersList)
            {
                currentChat.Interlocutors.Remove(user);
                Chats.FirstOrDefault(chat => chat.Id == currentChat.Id).Interlocutors.Remove(user);
            }
        }

        private void AddNewUsersToChat()
        {
            usersNotInChat = new ObservableCollection<User>(AllUsers.Except(currentChat.Interlocutors));
            UsersToAddWindow usersWindow = new UsersToAddWindow() { DataContext = this };
            usersWindow.ShowDialog();
        }

        private void ShowChatInfo()
        {
            ChatInfoWindow chatInfoWindow = new ChatInfoWindow() { DataContext = this };
            chatInfoWindow.ShowDialog();
        }

        private async Task CheckForExpiredMessagesAsync()
        {
            while (true)
            {
                try
                {
                    var now = DateTime.Now;
                    foreach (Chat chat in Chats)
                    {
                        var expiredMessages = chat.ChatMessages.Where(m => m.isDestroyMessage == true && m.timeToDestroy <= now).ToList();

                        if (expiredMessages.Count > 0)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                foreach (var message in expiredMessages)
                                {
                                    chat.ChatMessages.Remove(message);
                                    Console.WriteLine($"Бомба {message.MessageText} удалена");
                                    if (ChatMessages.Any(x => x == message))
                                    {
                                        ChatMessages.Remove(message);
                                    }
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении бомбы у клиента: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
        private void ShowProfile()
        {
            ProfileWindow profileWindow = new ProfileWindow() { DataContext = this };
            profileWindow.ShowDialog();
        }

        private void DestroyingMessageRecieved()
        {
            var id = server.packetReader.ReadMessage();
            var senderId = server.packetReader.ReadMessage();
            var senderName = server.packetReader.ReadMessage();
            var senderSurname = server.packetReader.ReadMessage();
            var time = server.packetReader.ReadMessage();
            var timeToDestroy = server.packetReader.ReadMessage();
            var chatID = server.packetReader.ReadMessage();
            var msg = server.packetReader.ReadMessage();
            Message recievedMessage = new Message(Guid.Parse(id), Guid.Parse(senderId), senderName, senderSurname, msg, DateTime.Parse(time), Guid.Parse(chatID), DateTime.Parse(timeToDestroy));
            MessageBox.Show(recievedMessage.timeToDestroy.ToString(),"Пришла бомба");
            //message.MessageText = msg; Guid.Parse(id), DateTime.Parse(time) ,username, msg
            Application.Current.Dispatcher.Invoke(() => {
                Chats.Where(x => x.Id == recievedMessage.chatId).FirstOrDefault().AddMessage(recievedMessage);
                //chat.AddMessage(recievedMessage);
                //ChatMessages.Add(new Message(Guid.Parse(id), Guid.Parse(senderId), msg, DateTime.Parse(time), Guid.Parse(chatID)));
            });
        }


        private void SendDestroingMessage(Guid senderId, string name, string surname, string messageText, Guid chatId, DateTime timeToDestroy)
        {
            try
            {
                MessageBox.Show(timeToDestroy.ToString());
                Message destroyingMessage = new Message(senderId, name, surname, messageText, chatId, timeToDestroy);
                server.SendDestroynigMessageToServer(destroyingMessage);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendMessage(Guid senderId, string name, string surname, string messageText, Guid chatId)
        {
            Message message = new Message(senderId, name, surname, messageText, chatId);
            server.SendMessageToServer(message);
        }
        private void LoadAllUsers()
        {
            var allUsers = server.packetReader.ReadUsers();
            foreach (User user in allUsers)
            {
                Application.Current.Dispatcher.Invoke(() => { AllUsers.Add(user); });
            }
        }

        private void ShowChats()
        {
            List<Chat> chats = server.packetReader.ReadChats();

            foreach (Chat chat in chats)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    
                    if(!Chats.Any(x=>x.Id == chat.Id))
                    {
                        Chats.Add(chat);
                        ChatRadioButton newRadioButton = new ChatRadioButton()
                        {
                            Content = chat.Name,
                            GroupName = "Chats",
                            Command = ShowChatCommand,
                            CommandParameter = chat.Id
                        };
                        RadioButtons.Add(newRadioButton);

                    }
                });
            }
            
        }
        private void ShowChat(Guid chatId)
        {
            if (currentChat == null)
            {
                currentChat = new Chat(Chats.FirstOrDefault(chat => chat.Id == chatId));
            }
            else
            {
                currentChat = Chats.FirstOrDefault(chat => chat.Id == chatId);
            }
            //ChatMessages.Clear();
            ChatMessages = currentChat.ChatMessages;
            //currentChat = new Chat(chatt.Id, chatt.Name, chatt.Interlocutors);
            //MessageBox.Show(currentChat.Name);
        }

        private void ShowNewChat()
        {
            var newChatId = Guid.Parse(server.packetReader.ReadMessage());
            var newChatName = server.packetReader.ReadMessage();
            var newChatIntroluctors = server.packetReader.ReadUserList();
            Chat newChat = new Chat(newChatId, newChatName, newChatIntroluctors);
            Application.Current.Dispatcher.Invoke(() =>
            {
                if(!Chats.Any(x=> x.Id == newChat.Id))
                {
                    Chats.Add(newChat);
                    ChatRadioButton newRadioButton = new ChatRadioButton()
                    {
                        Content = newChatName,
                        GroupName = "Chats",
                        Command = ShowChatCommand,
                        CommandParameter = newChatId
                    };
                    RadioButtons.Add(newRadioButton);
                }
            }
            );
        }


        private void CreateNewChat(string name, ObservableCollection<User> users)
        {            
            // создаем чат
            Chat newChat = new Chat(name, users);
            //Chats.Add(newChat);
            // отправляем чат на сервер
            server.SendNewChatData(newChat.Name, users);
            // добавляем новую кнопку чата
            //ChatRadioButton newRadioButton = new ChatRadioButton()
            //{
            //    Content = newChat.Name,
            //    GroupName = "Chats",
            //    Command = ShowChatCommand,
            //    CommandParameter = newChat.Id.ToString()
            //};
            //RadioButtons.Add(newRadioButton);
        }

        private void OnSelectionChanged()
        {
            NewChat_SelectedUsers.Clear();

            foreach (User user in selectedItems)
            {
                NewChat_SelectedUsers.Add(user);
            }
            
        }

        private void OpenNewChatDialog()
        {
            NewChatDialog newChat = new NewChatDialog() { DataContext = this };
            newChat.ShowDialog();
        }

        private void UserDisconnected()
        {
            var uid = Guid.Parse(server.packetReader.ReadMessage());
            var user = Users.Where(x => x.UID == uid).FirstOrDefault(); 
            Application.Current.Dispatcher.Invoke(() => Users.Remove(user));
        }

        private void MessageRecieved()
        {
            var id = server.packetReader.ReadMessage();
            var senderId = server.packetReader.ReadMessage();
            var senderName = server.packetReader.ReadMessage();
            var senderSurname = server.packetReader.ReadMessage();
            var time = server.packetReader.ReadMessage();
            var chatID = server.packetReader.ReadMessage();
            var msg = server.packetReader.ReadMessage();
            Message recievedMessage = new Message(Guid.Parse(id), Guid.Parse(senderId), senderName, senderSurname, msg, DateTime.Parse(time), Guid.Parse(chatID));
            //message.MessageText = msg; Guid.Parse(id), DateTime.Parse(time) ,username, msg
            Application.Current.Dispatcher.Invoke(() => {
                Chats.Where(x => x.Id == recievedMessage.chatId).FirstOrDefault().AddMessage(recievedMessage);
                //chat.AddMessage(recievedMessage);
                //ChatMessages.Add(new Message(Guid.Parse(id), Guid.Parse(senderId), msg, DateTime.Parse(time), Guid.Parse(chatID)));
            });
        }

        private void UserConnected()
        {
            var Username = server.packetReader.ReadMessage();
            var UID = Guid.Parse(server.packetReader.ReadMessage());
            var mail = server.packetReader.ReadMessage();
            var name = server.packetReader.ReadMessage();
            var surname = server.packetReader.ReadMessage();
            var post = server.packetReader.ReadMessage();
            var user = new User(UID, Username, mail, name, surname, post);            
            if(!Users.Any(x=>x.UID == user.UID))
            {
                Application.Current.Dispatcher.Invoke(() => Users.Add(user));
            }
        }
    }
}
