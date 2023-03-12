using ChatKrasnov.DB;
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

namespace ChatKrasnov
{
    /// <summary>
    /// Логика взаимодействия для UserWin.xaml
    /// </summary>
    public partial class UserWin : Window
    {
        public UserWin()
        {
            InitializeComponent();
            TbUserChat.Text = App.emp.Username;
            var lst = App.chatEntitiesDB.Employee_ChatRoom.Where(x => x.Employee.Id == App.emp.Id).ToList();
            lstchat.ItemsSource = lst;
        }

        private void BtnCloseAPP_Click(object sender, RoutedEventArgs e)
        {
            var mes = MessageBox.Show("Приложение будет закрыто?", "Закрытие приложения!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mes == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void BtnEmployeeFind_Click(object sender, RoutedEventArgs e)
        {
            EmpFinder finder = new EmpFinder();
            finder.Show();
        }

        private void lstchat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = (Employee_ChatRoom)lstchat.SelectedItem;
            new WinChat(a).Show();
            Close();
        }
    }
}
