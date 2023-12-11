using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateChat.Model
{
    public class DestroyingMessage : ViewModelBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime timeCreated { get; set; }
        public DateTime timeToDestroy { get; set; }
        public string MessageText { get; set; }
        public Guid chatId { get; set; }
        public DestroyingMessage(Guid senderId, string senderName, string senderSurname, string text, Guid chatId, DateTime timeToDestroy)
        {
            Id = Guid.NewGuid();
            UserId = senderId;
            UserName = senderName;
            UserSurname = senderSurname;
            timeCreated = DateTime.Now;
            MessageText = text;
            this.chatId = chatId;
            this.timeToDestroy = timeToDestroy;
        }

        public DestroyingMessage(Guid id, Guid senderId, string senderName, string senderSurname, string text, DateTime _timeCreated, Guid chatId, DateTime timeToDestroy)
        {
            Id = id;
            UserId = senderId;
            UserName = senderName;
            UserSurname = senderSurname;
            timeCreated = _timeCreated;
            MessageText = text;
            this.chatId = chatId;
            this.timeToDestroy = timeToDestroy;
        }
    }
}
