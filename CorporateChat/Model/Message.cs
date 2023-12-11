using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateChat.Model
{
    public class Message : ViewModelBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime timeCreated { get; set; }
        public bool isDestroyMessage { get; set; }
        public DateTime timeToDestroy { get; set; }
        public string MessageText { get; set; }
        public Guid chatId { get; set; }
        public Message(Guid senderId, string senderName, string senderSurname, string text, Guid chatId)
        {
            Id = Guid.NewGuid();
            UserId = senderId;
            UserName = senderName;
            UserSurname = senderSurname;
            timeCreated = DateTime.Now;
            isDestroyMessage = false;
            MessageText = text;
            this.chatId = chatId;
        }

        public Message(Guid id, Guid senderId, string senderName, string senderSurname, string text, DateTime _timeCreated, Guid chatId)
        {
            Id = id;
            UserId = senderId;
            UserName = senderName;
            UserSurname = senderSurname;
            timeCreated = _timeCreated;
            isDestroyMessage = false;
            MessageText = text;
            this.chatId = chatId;
        }

        public Message(Guid senderId, string senderName, string senderSurname, string text, Guid chatId, DateTime destroyTime)
        {
            Id = Guid.NewGuid();
            UserId = senderId;
            UserName = senderName;
            UserSurname = senderSurname;
            timeCreated = DateTime.Now;
            isDestroyMessage = true;
            timeToDestroy = destroyTime;
            MessageText = text;
            this.chatId = chatId;
        }

        public Message(Guid id, Guid senderId, string senderName, string senderSurname, string text, DateTime _timeCreated, Guid chatId, DateTime destroyTime)
        {
            Id = id;
            UserId = senderId;
            UserName = senderName;
            UserSurname = senderSurname;
            timeCreated = _timeCreated;
            isDestroyMessage = true;
            timeToDestroy = destroyTime;
            MessageText = text;
            this.chatId = chatId;
        }
    }
}
