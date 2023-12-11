using CorporateChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CorporateChat.View
{
    /// <summary>
    /// Логика взаимодействия для ChatInfoWindow.xaml
    /// </summary>
    public partial class ChatInfoWindow : Window
    {
        public ChatInfoWindow()
        {
            InitializeComponent();
        }
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            var viewModel = (MainViewModel)DataContext;
            viewModel.chatInfoSelectedItems = listBox.SelectedItems;
            viewModel.chatInfoSelectionChangedCommand.Execute(null);
        }
    }
}
