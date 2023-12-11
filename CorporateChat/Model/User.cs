using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateChat.Model
{
    public class User
    {
        public string Username { get; set; }
        public Guid UID { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Post { get; set; }
        public User(Guid id, string username, string mail, string name, string surname, string post)
        {
            UID = id;
            Username = username;
            Mail = mail;
            Name = name;
            Surname = surname;
            Post = post;
        }
        public User(Guid id, string name, string surname)
        {
            UID = id;
            Name = name;
            Surname = surname;
        }

    }

}
