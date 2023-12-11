using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateChat.Model
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<User> Interlocutors { get; set; }
        public ObservableCollection<Message> ChatMessages { get; set; }
        public Chat(string name, ObservableCollection<User> intorlocutors)
        {
            Name = name;
            Interlocutors = intorlocutors;
            ChatMessages = new ObservableCollection<Message>();
        }
        public Chat(Guid id, string name, ObservableCollection<User> intorlocutors)
        {
            Id = id;
            Name = name;
            Interlocutors = intorlocutors;
            ChatMessages = new ObservableCollection<Message>();
        }
        public Chat(Chat other)
        {
            Id = other.Id;
            Name = other.Name;
            Interlocutors = other.Interlocutors;
            ChatMessages = other.ChatMessages;
        }
        public void AddMessage(Message message)
        {
            ChatMessages.Add(message);
        }

    }
}
