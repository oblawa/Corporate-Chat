using CorporateChat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateChat.Network.IO
{
    
    internal class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder() 
        {
            _ms = new MemoryStream();
        }
        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }
        public void WriteMessage(string msg)
        {
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
            int msgLength = msgBytes.Length;

            byte[] buff = BitConverter.GetBytes(msgLength);
            _ms.Write(buff, 0, buff.Length);
            _ms.Write(msgBytes, 0, msgLength);
        }

        // Метод для записи списка пользователей
        public void WriteUserList(ObservableCollection<User> users)
        {
            // Запись количества пользователей в списке
            WriteInt32(users.Count);

            // Запись идентификаторов и имен пользователей
            foreach (User user in users)
            {
                WriteMessage(user.UID.ToString());
                WriteMessage(user.Name);
            }
        }
        public void WriteUserIDList(ObservableCollection<User> users)
        {
            // Запись количества пользователей в списке
            WriteInt32(users.Count);

            // Запись идентификаторов и имен пользователей
            foreach (User user in users)
            {
                WriteMessage(user.UID.ToString());
            }
        }
        public void WriteInt32(int value)
        {
            byte[] buff = BitConverter.GetBytes(value);
            _ms.Write(buff, 0, buff.Length);
        }
        // Метод для записи списка сообщений
        public void WriteMessageList(ObservableCollection<Message> messages)
        {
            // Запись количества сообщений в списке
            WriteInt32(messages.Count);

            // Запись идентификаторов, содержания, имен отправителей и временных меток сообщений
            foreach (Message message in messages)
            {
                WriteMessage(message.Id.ToString());
                WriteMessage(message.MessageText);
                WriteMessage(message.UserId.ToString());
                WriteDateTime(message.timeCreated);
            }
        }
        public void WriteDateTime(DateTime dateTime)
        {
            long value = dateTime.Ticks;
            byte[] buff = BitConverter.GetBytes(value);
            _ms.Write(buff, 0, buff.Length);
        }
        public byte[] GetPacketBytes() 
        {
            return _ms.ToArray(); 
        }
    }
}
