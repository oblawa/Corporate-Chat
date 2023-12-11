using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CorporateChat.View.Scripts
{
    public class LastItemInContainerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ContentPresenter contentPresenter && contentPresenter.Parent is ItemsControl itemsControl)
            {
                return itemsControl.Items.IndexOf(contentPresenter.Content) == itemsControl.Items.Count - 1;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
