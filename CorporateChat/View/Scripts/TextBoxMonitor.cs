using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace CorporateChat
{
    public class TextBoxMonitor : DependencyObject
    {
        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(TextBoxMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));



        public static int GetTextLength(DependencyObject obj)
        {
            return (int)obj.GetValue(TextLengthProperty);
        }

        public static void SetTextLength(DependencyObject obj, int value)
        {
            obj.SetValue(TextLengthProperty, value);
        }

        public static readonly DependencyProperty TextLengthProperty =
            DependencyProperty.RegisterAttached("TextLength", typeof(int), typeof(TextBoxMonitor), new UIPropertyMetadata(0));

        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var tb = d as TextBox;
            if (tb == null)
            {
                return;
            }
            if ((bool)e.NewValue)
            {
                tb.TextChanged += TextChanged;
            }
            else
            {
                tb.TextChanged -= TextChanged;
            }
        }

        static void TextChanged(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null)
            {
                return;
            }
            SetTextLength(tb, tb.Text.Length);
        }
    }
}
