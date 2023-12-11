using CorporateChat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CorporateServer.Network.IO
{
    //internal class PacketReader : BinaryReader
    //{
    //    private NetworkStream _ns;
    //    public PacketReader(NetworkStream ns) : base(ns)
    //    {
    //        _ns = ns;
    //    }

    //    public string ReadMessage()
    //    {
    //        byte[] msgBuffer;
    //        var length = ReadInt32();
    //        msgBuffer = new byte[length];
    //        _ns.Read(msgBuffer, 0, length);

    //        var msg = Encoding.UTF8.GetString(msgBuffer);
    //        return msg;
    //    }
    //}
    public class PacketReader : BinaryReader
    {
        private SslStream _sslStream;

        public PacketReader(SslStream sslStream) : base(sslStream)
        {
            _sslStream = sslStream;
        }

        public string ReadMessage()
        {
            byte[] msgBuffer;
            var length = ReadInt32();
            msgBuffer = new byte[length];
            _sslStream.Read(msgBuffer, 0, length);
            var msg = Encoding.UTF8.GetString(msgBuffer);
            return msg;
        }
        // Метод для чтения списка пользователей
        public ObservableCollection<User> ReadUserList()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            int userCount = ReadInt32();

            for (int i = 0; i < userCount; i++)
            {
                //Guid id = Guid.Parse(ReadMessage());
                //string username = ReadMessage();
                //string mail = ReadMessage();
                //users.Add(new User(id, username, mail));
                Guid id = Guid.Parse(ReadMessage());
                string username = ReadMessage();
                string mail = ReadMessage();
                string name = ReadMessage();
                string surname = ReadMessage();
                string post = ReadMessage();
                users.Add(new User(id, username, mail, name, surname, post));
            }

            return users;
        }
        public List<User> ReadUsers()
        {
            List<User> users = new List<User>();
            int userCount = ReadInt32();

            for (int i = 0; i < userCount; i++)
            {
                Guid id = Guid.Parse(ReadMessage());
                string username = ReadMessage();
                string mail = ReadMessage();
                string name = ReadMessage();
                string surname = ReadMessage();
                string post = ReadMessage();
                users.Add(new User(id, username, mail,name,surname,post));
            }

            return users;
        }

        //// Метод для чтения списка сообщений
        //public List<Message> ReadMessageList()
        //{
        //    List<Message> messages = new List<Message>();
        //    int messageCount = ReadInt32();

        //    for (int i = 0; i < messageCount; i++)
        //    {
        //        Guid id = Guid.Parse(ReadMessage());
        //        string content = ReadMessage();
        //        Guid senderId = Guid.Parse(ReadMessage());
        //        string senderName = ReadMessage();
        //        DateTime timestamp = ReadDateTime();
        //        Guid chatId = Guid.Parse(ReadMessage());
        //        messages.Add(new Message(id, senderId, senderName, content, timestamp, chatId));
        //    }
        //    return messages;
        //}
        public List<Chat> ReadChats()
        {
            List<Chat> chats = new List<Chat>();

            // Читаем количество чатов
            int chatCount = ReadInt32();

            for (int i = 0; i < chatCount; i++)
            {
                // Читаем ID чата
                Guid chatId = Guid.Parse(ReadMessage());

                // Читаем имя чата
                string chatName = ReadMessage();

                // Читаем количество участников чата
                int interlocutorCount = ReadInt32();
                ObservableCollection<User> interlocutors = new ObservableCollection<User>();

                for (int j = 0; j < interlocutorCount; j++)
                {
                    // Читаем ID участника
                    Guid userId = Guid.Parse(ReadMessage());

                    // Читаем имя участника
                    string name = ReadMessage();
                    string surname = ReadMessage();
                    // Добавляем участника в список interlocutors
                    interlocutors.Add(new User(userId, name, surname));
                }

                // Создаем чат с участниками
                Chat chat = new Chat(chatId, chatName, interlocutors);

                // Читаем количество сообщений в чате
                int messageCount = ReadInt32();

                for (int k = 0; k < messageCount; k++)
                {
                    // Читаем ID сообщения
                    Guid messageId = Guid.Parse(ReadMessage());

                    // Читаем время создания сообщения
                    DateTime messageTime = DateTime.Parse(ReadMessage());

                    // Читаем ID отправителя сообщения
                    Guid senderId = Guid.Parse(ReadMessage());
                    //  Читаем Имя отправителя
                    string senderName = ReadMessage();
                    string senderSurname = ReadMessage();
                    // Читаем текст сообщения
                    string messageText = ReadMessage();

                    // Добавляем сообщение в чат
                    chat.AddMessage(new Message(messageId, senderId, senderName, senderSurname, messageText, messageTime, chatId));
                }

                // Добавляем чат в список chats
                chats.Add(chat);
            }

            return chats;
        }

        //public List<Chat> ReadChats()
        //{
        //    List<Chat> chats = new List<Chat>();

        //    // Читаем количество чатов
        //    int chatCount = ReadInt32();

        //    for (int i = 0; i < chatCount; i++)
        //    {
        //        // Читаем ID чата
        //        Guid chatId = Guid.Parse(ReadMessage());

        //        // Читаем имя чата
        //        string chatName = ReadMessage();

        //        // Читаем количество участников чата
        //        int interlocutorCount = ReadInt32();
        //        ObservableCollection<User> interlocutors = new ObservableCollection<User>();

        //        for (int j = 0; j < interlocutorCount; j++)
        //        {
        //            // Читаем ID участника
        //            Guid userId = Guid.Parse(ReadMessage());

        //            // Читаем имя участника
        //            string username = ReadMessage();

        //            // Добавляем участника в список interlocutors
        //            interlocutors.Add(new User(userId, username));
        //        }

        //        // Добавляем чат в список chats
        //        chats.Add(new Chat(chatId, chatName, interlocutors));
        //    }

        //    return chats;
        //}
        public DateTime ReadDateTime()
        {
            long value = ReadInt64();
            return new DateTime(value);
        }
    }
}
