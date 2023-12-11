using CorporateChat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CorporateChat.View.Scripts
{
    public class TopThreeInterlocutorsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<User> interlocutors)
            {
                if (interlocutors.Count > 3)
                {
                    return interlocutors.Take(3).ToList();
                }
                return interlocutors;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
