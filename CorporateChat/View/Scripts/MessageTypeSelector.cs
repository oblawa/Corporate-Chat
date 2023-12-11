using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace CorporateChat.View.Scripts
{
    public class MessageTypeSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is 2)
            {
                return (DataTemplate)Application.Current.FindResource("MessageType");
            }
            else if (item is 1)
            {
                return (DataTemplate)Application.Current.FindResource("MessageType");
            }
            // return default template if no specific template found
            return base.SelectTemplate(item, container);
        }
    }
}
