using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CorporateChat.View.Scripts
{
    internal class ChatRadioButton:RadioButton
    {
        public ChatRadioButton()
        {
            
            this.Style = (Style)Application.Current.FindResource("ChatRbStyle");
        }
    }
}
